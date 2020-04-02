using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    static public int maxHealth = 50;
    public int currentHealth;
    public int points = 10;
    static public int damageTaken = 10;
    int gameOverCount;

    bool adjustFlag = false;

    void Start()
    {
        gameOverCount = FindObjectOfType<GameManager>().getGameOverCount();
        adjustFlag = false;

        if (gameOverCount % 3 != 0 || gameOverCount == 0 || adjustFlag)
        {
            currentHealth = maxHealth;
        }
        else if (!adjustFlag)
        {
            maxHealth -= Convert.ToInt32(maxHealth * 0.2);
            currentHealth = maxHealth;
            adjustFlag = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BProjectile"))
        {
            if (gameOverCount % 3 != 0 || gameOverCount == 0 || adjustFlag)
            {
                TakeDamage(damageTaken);
            }
            else if (!adjustFlag)
            {
                damageTaken += Convert.ToInt32(damageTaken * 0.5);
                TakeDamage(damageTaken);
            }
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        FindObjectOfType<Score>().setScore(points);
        Destroy(gameObject);
    }
}

