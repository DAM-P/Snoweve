using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManu : MonoBehaviour
{
    public float delaySeconds = 1f;
    // Start is called before the first frame update
    public void StartGame()
    {
        Time.timeScale = 1f;
        //Debug.Log(1);
        //SceneManager.LoadScene(1);
        Invoke("begin", delaySeconds);
        GetComponent<Interim>().StartTransition();


    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void begin()
    {
        Debug.Log(12);
        SceneManager.LoadScene(1); // ������Ϸ�������������ָ���ʵ�����ã�

    }
}
