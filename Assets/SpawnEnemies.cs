using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [Tooltip("Prefab of the enemy to spawn.")]
    public Rigidbody2D enemy;
    public Rigidbody2D enemy2;
    [Tooltip("Intervalle between each enemies spawn in secondes.")]
    public float intervalleSpawn;
    private float iniTime;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.fixedTime - iniTime > intervalleSpawn)
        {
            int randomEnemy = Random.Range(1, 3);
            Rigidbody2D enemyClone = (Rigidbody2D)Instantiate((randomEnemy == 1) ? (enemy) : (enemy2), transform.position, transform.rotation);
            iniTime = Time.fixedTime;
        }
    }
}
