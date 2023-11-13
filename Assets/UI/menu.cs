using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenu;
    public bool isPaused = false;
    private void Start()
    {
        pauseMenu.SetActive(isPaused);
    }

    public void TogglePauseMenu()

    {
        //Debug.Log("ttt");
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);
        if (isPaused)
        {
            GetComponent<Animator>().Play("pause");
        }
        else
        {
            GetComponent<Animator>().Play("Play");
        }
        
        Time.timeScale = isPaused ? 0f : 1f;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
