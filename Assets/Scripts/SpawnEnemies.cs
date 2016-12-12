using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    public GameObject Spawn(Team team, Character charac)
    {
        charac.team = team;
        return charac.CharacterSpawn(transform.position);
    }

    public void Spawn(Team team, Character[] characs)
    {
        int randomEnemy = Random.Range(0, characs.Length);
        Character toSpawn = characs[randomEnemy];
        toSpawn.team = team;
        toSpawn.CharacterSpawn(transform.position);
    }
}
