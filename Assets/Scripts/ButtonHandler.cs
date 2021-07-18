using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void again() {
        SceneManager.LoadScene("Level1");    
    }
    public void exit() {
        Debug.Log("Sali");
        Application.Quit();
    }
}
