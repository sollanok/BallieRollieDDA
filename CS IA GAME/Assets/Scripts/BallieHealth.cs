
using UnityEngine;

public class BallieHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public int regularDamage = 15;
    public int ladyBugDamage = 20;
    int gameOverCount;

    void setRegularDamage(int damage)
    {
        regularDamage -= damage;
    }

    void setLadyBugDamage(int damage)
    {
        ladyBugDamage -= damage;
    }

    // Start is called before the first frame update
    void Start()
    {

        currentHealth = maxHealth;
        gameOverCount = FindObjectOfType<GameManager>().getGameOverCount();

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (gameOverCount <= 2)
            {
                setRegularDamage(0);
                TakeDamage(regularDamage);
            }
            else if (gameOverCount >= 3 && gameOverCount <= 6)
            {
                setRegularDamage(5);
                TakeDamage(regularDamage);
            }
            else if (gameOverCount > 6)
            {
                setRegularDamage(10);
                TakeDamage(regularDamage);
            }
        }
        if (collision.CompareTag("LadyBug")){
            if (gameOverCount <= 2)
            {
                setLadyBugDamage(0);
                TakeDamage(ladyBugDamage);
            }
            else if (gameOverCount >= 3 && gameOverCount <= 6)
            {
                setLadyBugDamage(5);
                TakeDamage(ladyBugDamage);
            }
            else if (gameOverCount > 6)
            {
                setLadyBugDamage(10);
                TakeDamage(ladyBugDamage);
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

