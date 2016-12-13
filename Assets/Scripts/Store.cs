using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour {

    Team team = Team.Neutral;
    public Bouton_Manager manager;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    private void Update()
    {
        print("Alive");
    }
    public void setFlint()
    {
        this.team = Team.Flint;
        manager.New_btm("main");
    }
    public void setConner()
    {
        this.team = Team.Conner;
        manager.New_btm("main");
    }
    public void setKya()
    {
        this.team = Team.Kya;
        manager.New_btm("main");
    }
    public void setSaria()
    {
        this.team = Team.Saria;
        manager.New_btm("main");
    }
    public Team getTeam()
    {
        return (this.team);
    }
}
