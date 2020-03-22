using UnityEngine;

public class Enemy1 : MonoBehaviour
{

    float startTimeBewtweenShots = 2f;
    float timeBetweenShots;
    int gameOverCount;

    public GameObject projectile;

    void setTime(float time)
    {
        startTimeBewtweenShots += time;
        timeBetweenShots += time;
    }


    // Start is called before the first frame update
    public void Start()
    {

        gameOverCount = FindObjectOfType<GameManager>().getGameOverCount();

        if (gameOverCount <= 2)
        {
            timeBetweenShots = startTimeBewtweenShots;
        }
        else if (gameOverCount >= 3 && gameOverCount <= 6)
        {
            setTime(1f);
        }
        else if (gameOverCount > 6)
        {
            setTime(2f);
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (timeBetweenShots <= 0)
        {

            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBetweenShots = startTimeBewtweenShots;

        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }

    }
}
