using UnityEngine;

public class Enemy1 : MonoBehaviour
{

    static float startTimeBewtweenShots = 2f;
    float timeBetweenShots;
    int gameOverCount;

    public GameObject projectile;

    bool adjustFlag = false;

    // Start is called before the first frame update
    public void Start()
    {
        gameOverCount = FindObjectOfType<GameManager>().getGameOverCount();
        adjustFlag = false;

        if (gameOverCount % 3 != 0 || gameOverCount == 0 || adjustFlag)
        {
            timeBetweenShots = startTimeBewtweenShots;
        }
        else if (!adjustFlag)
        {
            startTimeBewtweenShots += 1f;
            timeBetweenShots = startTimeBewtweenShots;
            adjustFlag = true;
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

