using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public int points = 10;
    int gameOverCount;

    void setHealth(int health)
    {
        maxHealth -= health;
        currentHealth = maxHealth;
    }

    void Start()
    {
        gameOverCount = FindObjectOfType<GameManager>().getGameOverCount();

        if (gameOverCount <= 2)
        {
            setHealth(0);
        }
        else if (gameOverCount >= 3 && gameOverCount <= 6)
        {
            setHealth(10);
        }
        else if (gameOverCount > 6)
        {
            setHealth(20);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BProjectile"))
        {
            if (gameOverCount <= 2)
            {
                TakeDamage(5);
            }
            else if (gameOverCount >= 3 && gameOverCount <= 6)
            {
                TakeDamage(10);
            }
            else if (gameOverCount > 6)
            {
                TakeDamage(20);
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

