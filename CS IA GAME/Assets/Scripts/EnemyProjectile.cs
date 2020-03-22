using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    public float speed;

    private Transform Ballie;
    private Vector2 target;


    // Start is called before the first frame update
    void Start()
    {

        Ballie = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(Ballie.position.x, Ballie.position.y);

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, target,
            speed * Time.deltaTime);

        if (transform.position.x == target.x
            && transform.position.y == target.y)
        {
            DestroyProjectile();
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

}

