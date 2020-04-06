using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool gameEnded = false;
    public float restartDelay = 1f;

    static int gameOverCount;

    public GameObject completeLevelUI;



    public int getGameOverCount()
    {
        return gameOverCount;
    }


    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }

    public void GameOver()
    {
        if (gameEnded == false)
        {
            gameEnded = true;
            Invoke("Restart",restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverCount++;
        Screen.fullScreen = false;
        Debug.Log("Game over counter " + gameOverCount);
    }
}
