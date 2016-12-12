using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide_Manager : MonoBehaviour {

    public GameObject menu;
    public GameObject Bouton;

    private bool isHide;

    private void Start()
    {
        isHide = true;
    }

    public void ShowHideMenu()
    {
        isHide = !isHide;
        menu.SetActive(isHide);
    }
}
