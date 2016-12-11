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
    public void Spawn(Team team)
    {
        int randomEnemy = Random.Range(1, 3);
        Character toSpawn = (randomEnemy == 1) ? (enemy) : (enemy2);
        toSpawn.team = team;
        toSpawn.CharacterSpawn(transform.position);
    }
}
