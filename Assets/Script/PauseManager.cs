using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseManager : MonoBehaviour
{
    public GameObject UIContinue, UIExit;
    
    private void Update() {
    if(Input.GetKeyDown(KeyCode.Escape)){

        Cursor.lockState = CursorLockMode.None;
        UIContinue.SetActive(true);
        UIExit.SetActive(true);
        Time.timeScale=0;
    }    
    }

    public void Continue(){
    Time.timeScale=1;
    Cursor.lockState = CursorLockMode.Locked;   
    UIContinue.SetActive(false);
    UIExit.SetActive(false);
    
    }

    public void Exit()
    {
        Application.Quit();    
    }
}
