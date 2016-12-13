using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Circle : MonoBehaviour {

    public Character player;
    public Scrollbar FlintBar;
    public Scrollbar ConnerBar;
    public Scrollbar KyaBar;
    public Scrollbar SariaBar;
    public float time;
    private float ConnerTime;
    private float FlintTime;
    private float KyaTime;
    private float SariaTime;
    // Use this for initialization
    void Start () {
        ConnerTime = time;
        FlintTime = time;
        KyaTime = time;
        SariaTime = time;
    }
    List<Character> inCircle = new List<Character>();
    // Update is called once per frame
    bool isNull(Character chara)
    {
        return (chara == null);
    }
    void Update () {

        List<Character> toDelete = new List<Character>();
        bool empty = true;
        foreach (Character chara in inCircle)
        {
            if (chara != player)
                empty = false;
        }
        inCircle.RemoveAll(isNull);
        if (!empty)
        {
            bool ok = true;
            foreach (Character chara in inCircle)
            {
                if (chara != player)
                    ok = (chara.team == Team.Flint) ? ok : false;
            }
            if (ok)
            {
                FlintTime -= Time.deltaTime;
                FlintBar.size = FlintTime / time;
                if (FlintTime <= 0.0f)
                {
                    if (player.team == Team.Flint)
                    {
                        SceneManager.LoadScene("Win");
                    }
                    else
                    {
                        SceneManager.LoadScene("GameOver");
                    }
                }
            }
            ok = true;
            foreach (Character chara in inCircle)
            {
                if (chara != player)
                    ok = (chara.team == Team.Conner) ? ok : false;
            }
            if (ok)
            {
                ConnerTime -= Time.deltaTime;
                ConnerBar.size = ConnerTime / time;
                if (ConnerTime <= 0.0f)
                {
                    if (player.team == Team.Conner)
                    {
                        SceneManager.LoadScene("Win");
                    }
                    else
                    {
                        SceneManager.LoadScene("GameOver");
                    }
                }
            }
            ok = true;
            foreach (Character chara in inCircle)
            {
                if (chara != player)
                    ok = (chara.team == Team.Kya) ? ok : false;
            }
            if (ok)
            {
                KyaTime -= Time.deltaTime;
                KyaBar.size = KyaTime / time;
                if (KyaTime <= 0.0f)
                {
                    if (player.team == Team.Kya)
                    {
                        SceneManager.LoadScene("Win");
                    }
                    else
                    {
                        SceneManager.LoadScene("GameOver");
                    }
                }
            }
            ok = true;
            foreach (Character chara in inCircle)
            {
                if (chara != player)
                    ok = (chara.team == Team.Saria) ? ok : false;
            }
            if (ok)
            {
                SariaTime -= Time.deltaTime;
                SariaBar.size = SariaTime / time;
                if (SariaTime <= 0.0f)
                {
                    if (player.team == Team.Saria)
                    {
                        SceneManager.LoadScene("Win");
                    }
                    else
                    {
                        SceneManager.LoadScene("GameOver");
                    }
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Character chara = collision.GetComponent<Character>();
        if (chara != null)
        {
            inCircle.Add(chara);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Character chara = collision.GetComponent<Character>();
        if (chara != null)
        {
            inCircle.Remove(chara);
        }
    }
}
