using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth; 

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BProjectile"))
        {
            TakeDamage(10);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

}
