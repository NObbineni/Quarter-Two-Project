using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    bool gameEnd = false;

    public GameObject completeLevelUI;

	public void EndGame()
    {
        if (gameEnd == false)
        {
            gameEnd = true;
            Debug.Log("Game Over");
            Invoke("Restart", 1f);
           // Restart();
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteLevel()
    {
        Debug.Log("Level Complete");
        completeLevelUI.SetActive(true);
    }

}
