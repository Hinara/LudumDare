using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [Tooltip("Prefab of the enemy to spawn.")]
    public Rigidbody2D enemy;
    [Tooltip("Intervalle between each enemies spawn in secondes.")]
    public float intervalleSpawn;
    private float iniTime;
    // Use this for initialization
    void Start()
    {
        iniTime = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.fixedTime - iniTime > intervalleSpawn)
        {
            Rigidbody2D enemyClone = (Rigidbody2D)Instantiate(enemy, transform.position, transform.rotation);
            iniTime = Time.fixedTime;
        }
    }
}
