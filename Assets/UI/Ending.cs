using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject End,parent;
    public GameObject Winner;
    public bool isPaused = false, Continue = false,winner1;
    private void Start()
    {
        // Debug.Log("tyt");
        End.SetActive(isPaused);
    }
    private void Update()
    {
        //Debug.Log("ttyt");

    }
    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void EndMenu()

    {   isPaused = !isPaused;
        End.SetActive(isPaused);
        if (winner1)
        {
            Transform Win=parent.transform.Find("P1");
            Winner = Win.gameObject;
        }
        else
        {
            Transform Win = parent.transform.Find("P2");
            Winner = Win.gameObject;
        }
        //
        
        Winner.SetActive(isPaused);
        //Debug.Log("ttt");
        
        Time.timeScale = isPaused ? 0f : 1f;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
