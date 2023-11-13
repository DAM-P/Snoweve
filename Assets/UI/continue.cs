using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class continue1 : MonoBehaviour
{
    public GameObject Menu;
    // Start is called before the first frame update
    void Start()
    {
        Menu = GetComponent<GameObject>();
    }
    void Continue()
    {
        Menu.GetComponent<PauseMenu>().Continue = true;
    //    Menu.GetComponent<PauseMenu>().TogglePauseMenu();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
