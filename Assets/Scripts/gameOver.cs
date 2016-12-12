using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour {

	// Use this for initialization
	public void Quit (string quit)
    {
        Application.Quit();	
	}
	
	// Update is called once per frame
	public void Continue ()
    {
        SceneManager.LoadScene("Menu");
    }
}
