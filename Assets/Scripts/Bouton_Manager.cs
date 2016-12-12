using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Bouton_Manager : MonoBehaviour
{
    public void New_btm(string New_Level)
    {  
       SceneManager.LoadScene(New_Level);  
    }
    public void Exit_Game()
    {
        Application.Quit();
    }
}   
