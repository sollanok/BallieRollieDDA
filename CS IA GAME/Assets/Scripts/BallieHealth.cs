using System;
using UnityEngine;

public class BallieHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    static public int regularDamage = 10;
    static public int ladyBugDamage = 15;
    int gameOverCount;

    bool adjustFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        gameOverCount = FindObjectOfType<GameManager>().getGameOverCount();
        adjustFlag = false;
        Screen.fullScreen = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (gameOverCount % 3 != 0 || gameOverCount == 0 || adjustFlag)
            {
                TakeDamage(regularDamage);
                //Debug.Log("Enemy damage taken: " + regularDamage);
            }
            else if (!adjustFlag)
            {
                regularDamage -= Convert.ToInt32(regularDamage * 0.2);
                TakeDamage(regularDamage);
                adjustFlag = true;
                //Debug.Log("Enemy damage taken: " + regularDamage);
            }
        }
        if (collision.CompareTag("LadyBug"))
        {
            if (gameOverCount % 3 != 0 || gameOverCount == 0 || adjustFlag)
            {
                TakeDamage(ladyBugDamage);
                //Debug.Log("Enemy damage taken: " + ladyBugDamage);
            }
            else if (!adjustFlag)
            {
                ladyBugDamage -= Convert.ToInt32(ladyBugDamage * 0.2);
                TakeDamage(ladyBugDamage);
                adjustFlag = true;
                //Debug.Log("Enemy damage taken: " + ladyBugDamage);
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
                //Debug.Log("Enemy damage taken: " + regularDamage);
            }
            else if (!adjustFlag)
            {
                regularDamage -= Convert.ToInt32(regularDamage * 0.2);
                TakeDamage(regularDamage);
                adjustFlag = true;
                //Debug.Log("Enemy damage taken: " + regularDamage);
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

