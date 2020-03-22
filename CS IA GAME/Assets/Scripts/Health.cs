using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Text HealthText;

    void Start()
    {
        HealthText.text = "Health 100/100";
    }

    void Update()
    {

        HealthText.text = "Health " +
            gameObject.GetComponent<BallieHealth>().currentHealth.ToString() +
            "/" +
            gameObject.GetComponent<BallieHealth>().maxHealth.ToString();

    }
}
