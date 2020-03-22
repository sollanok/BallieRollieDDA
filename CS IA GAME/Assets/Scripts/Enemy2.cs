using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    /**
    public float timeToUp;
    public float startTimeToUp;

    // Start is called before the first frame update
    void Start()
    {
        timeToUp = startTimeToUp;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        timeToUp -= Time.deltaTime;

        if (timeToUp <= 0 && timeToUp > -(startTimeToUp))
        {
            Debug.Log("Down");
            gameObject.SetActive(false);
        }
        if (timeToUp <= -(startTimeToUp))
        {
            Debug.Log("Up");
            gameObject.SetActive(true);
            timeToUp = startTimeToUp;
        }
    }
    **/
}