using UnityEngine;
using Pathfinding;

public class Enemy4AI : MonoBehaviour
{

    public Transform target;
    public float speed = 200f; // This would change with player failure
    public float toNextWaypoint = 3f;

    Path path;
    int currentWaypoint;
    bool endOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    int gameOverCount;

    void setSpeed(float quantity)
    {
        speed -= quantity;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOverCount = FindObjectOfType<GameManager>().getGameOverCount();
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

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
  
        if (gameOverCount <= 2)
        {
            setSpeed(0);
        }
        else if (gameOverCount >= 3 && gameOverCount <= 6)
        {
            setSpeed(0.5f);
        }
        else if (gameOverCount > 6)
        {
            setSpeed(10f);
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


