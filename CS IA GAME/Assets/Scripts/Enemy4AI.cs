using UnityEngine;
using Pathfinding;
using System;

public class Enemy4AI : MonoBehaviour
{

    public Transform target;
    static public float speed = 200f;
    public float toNextWaypoint = 3f;

    Path path;
    int currentWaypoint;
    bool endOfPath = false;

    bool adjustFlag = false;

    Seeker seeker;
    Rigidbody2D rb;

    int gameOverCount;

    // Start is called before the first frame update
    void Start()
    {
        gameOverCount = FindObjectOfType<GameManager>().getGameOverCount();
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        adjustFlag = false;

        InvokeRepeating("UpdatePath", 0f, 0.5f);

    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, CompletePath);
        }
    }

    void CompletePath(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            endOfPath = true;
        }
        else
        {
            endOfPath = false;
        }

        if (gameOverCount % 3 == 0 && gameOverCount != 0 && !adjustFlag)
        {
            speed -= Convert.ToInt32(speed * 0.02);
            adjustFlag = true;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] -
            rb.position).normalized;

        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position,
            path.vectorPath[currentWaypoint]);

        if (distance < toNextWaypoint)
        {
            currentWaypoint++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}


