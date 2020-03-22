using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPot : MonoBehaviour
{

    public float timeToUp;
    public float startTimeToUp;

    public GameObject cactus;

    // Start is called before the first frame update
    void Start()
    {

        timeToUp = startTimeToUp;
        cactus.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (timeToUp <= 0 && timeToUp > -startTimeToUp)
        {
            cactus.SetActive(false);
        }
        if (timeToUp <= -startTimeToUp)
        {
            cactus.SetActive(true);
            timeToUp = startTimeToUp;
        }
        else
        {
            timeToUp -= Time.deltaTime;
        }
    }
}
