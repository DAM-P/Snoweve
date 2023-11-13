using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public Ending end;
    public bool isPaused = false,Continue=false,ifWin=false;
    private void Start()
    {
        // Debug.Log("tyt");
        end = GetComponent<Ending>();
        Time.timeScale = 1f;
         pauseMenu.SetActive(isPaused);
    }
    private void Update()
    {
        //Debug.Log("ttyt");

        if (Input.GetKeyDown(KeyCode.Tab))
        {//Debug.Log("ttyt");
         //   Continue = false;
         
            if (end.isPaused)
            {
                return;
            }    
            
            TogglePauseMenu();
            
        }
    }

    public void TogglePauseMenu()

    {
        //Debug.Log("ttt");
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);

        Time.timeScale = isPaused ? 0f : 1f;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
