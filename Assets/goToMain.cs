using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class goToMain : MonoBehaviour {

    public void New_btm(string New_Level)
    {
        SceneManager.LoadScene(New_Level);
    }
}
