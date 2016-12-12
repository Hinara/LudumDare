using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TextBox_Manager : MonoBehaviour
{

    public GameObject textBox;
    public GameObject hide_Bouton1;
    public GameObject hide_Bouton2;
    public GameObject hide_Bouton3;
    public GameObject hide_Bouton4;
    public GameObject hide_Bouton5;
    public GameObject Transition;
    //La window
    public Text theText;
    public Text Bouton_1;
    public Text Bouton_2;
    public Text Bouton_3;
    public Text Bouton_4;
    public Text Bouton_5;
    //le text à afficher sur la boite et sur les boutons

    public TextAsset textFile;
    //Le fichier
    public string[] Lines;

    public int Actual_Line;
    //La ligne ou on est
    public int End_line;
    //la derniere ligne que l'on veut lire



    public GameObject menu;
    public GameObject menu2;

    private bool isHide;

    private int Answer;

    private void Start()
    {
        isHide = true;
        Answer = 0;


        if (textFile != null)
        {
            Lines = (textFile.text.Split('\n'));
            //on split le text tout les '\n'
        }

        if (End_line == 0)
        {
            End_line = Lines.Length - 1;
        }
        theText.text = Lines[Actual_Line];
        Bouton_1.text = Lines[Actual_Line + 1];
        Bouton_2.text = Lines[Actual_Line + 2];
        Bouton_3.text = Lines[Actual_Line + 3];
        hide_Bouton4.SetActive(false);
        hide_Bouton5.SetActive(false);
    }
    public void Choix_1()
    {
        Answer = Answer + 1;
        if (Answer == 1)
        {
            hide_Bouton4.SetActive(true);
            hide_Bouton5.SetActive(true);
            theText.text = Lines[8];
            Bouton_1.text = Lines[12];
            Bouton_2.text = Lines[13];
            Bouton_3.text = Lines[14];
            Bouton_4.text = Lines[15];
            Bouton_5.text = Lines[16];
        }
        if (Answer == 2)
        {
            theText.text = Lines[18];
            Bouton_1.text = Lines[24];
            hide_Bouton1.SetActive(true);
            hide_Bouton2.SetActive(false);
            hide_Bouton3.SetActive(false);
            hide_Bouton4.SetActive(false);
            hide_Bouton5.SetActive(false);
        }
        if (Answer == 3)
        {
            menu.SetActive(false);
            menu2.SetActive(true);
        }
    }
    public void Choix_2()
    {
        Answer = Answer + 1;
        if (Answer == 1)
        {
            hide_Bouton4.SetActive(true);
            hide_Bouton5.SetActive(true);
            theText.text = Lines[9];
            Bouton_1.text = Lines[12];
            Bouton_2.text = Lines[13];
            Bouton_3.text = Lines[14];
            Bouton_4.text = Lines[15];
            Bouton_5.text = Lines[16];
        }
        if (Answer == 2)
        {
            theText.text = Lines[19];
            Bouton_1.text = Lines[24];
            hide_Bouton1.SetActive(true);
            hide_Bouton2.SetActive(false);
            hide_Bouton3.SetActive(false);
            hide_Bouton4.SetActive(false);
            hide_Bouton5.SetActive(false);
        }
    }
    public void Choix_3()
    {
        Answer = Answer + 1;
        if (Answer == 2)
        {
            theText.text = Lines[20];
            Bouton_1.text = Lines[24];
            hide_Bouton1.SetActive(true);
            hide_Bouton2.SetActive(false);
            hide_Bouton3.SetActive(false);
            hide_Bouton4.SetActive(false);
            hide_Bouton5.SetActive(false);
        }
        if (Answer == 1)
        {
            theText.text = "...";
            Bouton_1.text = Lines[24];
            hide_Bouton1.SetActive(true);
            hide_Bouton2.SetActive(false);
            hide_Bouton3.SetActive(false);
            hide_Bouton4.SetActive(false);
            hide_Bouton5.SetActive(false);
            //Answer = Answer + 1;
        }
    }
    public void Choix_4()
    {
        if (Answer == 1)
            Answer = Answer + 1;
        if (Answer == 2)
        {
            theText.text = Lines[10];
            Bouton_1.text = Lines[24];
            hide_Bouton1.SetActive(true);
            hide_Bouton2.SetActive(false);
            hide_Bouton3.SetActive(false);
            hide_Bouton4.SetActive(false);
            hide_Bouton5.SetActive(false);
        }
    }
    public void Choix_5()
    {
        if (Answer == 1)
            Answer = Answer + 1;
        if (Answer == 2)
        {
            theText.text = Lines[22];
            hide_Bouton1.SetActive(false);
            hide_Bouton2.SetActive(false);
            hide_Bouton3.SetActive(false);
            hide_Bouton4.SetActive(false);
            hide_Bouton5.SetActive(false);
            Transition.SetActive(true);
        }
    }
        public void New_btm(string New_Level)
        {
            SceneManager.LoadScene(New_Level);
        }
}
