using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public Text TimerText;
    float startTime = 0;
    float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {

        startTime = Time.timeSinceLevelLoad * Time.deltaTime;

    }

    // Update is called once per frame
    void Update()
    {

        currentTime = Time.timeSinceLevelLoad - startTime;

        string minutes = ((int)currentTime / 60).ToString();
        string seconds = ((int)currentTime % 60).ToString();

        TimerText.text = "Timer   0" + minutes + ":" + seconds;

    }
}

