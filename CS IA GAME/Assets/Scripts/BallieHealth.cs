using System;
using UnityEngine;

public class BallieHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    static public int regularDamage = 10;
    public int ladyBugDamage = 15;
    int gameOverCount;

    bool adjustFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        gameOverCount = FindObjectOfType<GameManager>().getGameOverCount();
        adjustFlag = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (gameOverCount % 3 != 0 || gameOverCount == 0 || adjustFlag)
            {
                TakeDamage(regularDamage);
            }
            else if (!adjustFlag)
            {
                regularDamage -= Convert.ToInt32(regularDamage * 0.2);
                TakeDamage(regularDamage);
                adjustFlag = true;
            }
        }
        if (collision.CompareTag("LadyBug"))
        {
            if (gameOverCount % 3 != 0 || gameOverCount == 0 || adjustFlag)
            {
                TakeDamage(ladyBugDamage);
            }
            else if (!adjustFlag)
            {
                ladyBugDamage -= Convert.ToInt32(ladyBugDamage * 0.2);
                TakeDamage(ladyBugDamage);
                adjustFlag = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (gameOverCount % 3 != 0 || gameOverCount == 0 || adjustFlag)
            {
                TakeDamage(regularDamage);
            }
            else if (!adjustFlag)
            {
                regularDamage -= Convert.ToInt32(regularDamage * 0.2);
                TakeDamage(regularDamage);
                adjustFlag = true;
            }
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}

