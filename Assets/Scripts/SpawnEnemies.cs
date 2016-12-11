using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [Tooltip("Prefab of the enemy to spawn.")]
    public Character enemy;
    public Character enemy2;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    public void Spawn(Team team, Character charac)
    {
        charac.team = team;
        charac.CharacterSpawn(transform.position);
    }

    public void Spawn(Team team, Character[] characs)
    {
        int randomEnemy = Random.Range(0, characs.Length);
        Character toSpawn = characs[randomEnemy];
        toSpawn.team = team;
        toSpawn.CharacterSpawn(transform.position);
    }
}
