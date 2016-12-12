using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hubSpawn : MonoBehaviour {
    [Tooltip("Team the hub belong to.")]
    public Team team;
    [Tooltip("List of spawners the hub have.")]
    public SpawnEnemies[] spawners;
    [Tooltip("List of characters who can spawn.")]
    public Character[] characs;
    [Tooltip("Chief of the hub.")]
    public Character chief;
    [Tooltip("Intervalle between each characters spawn in secondes.")]
    public float intervalleSpawn;
    private float iniTime;
    private GameObject boss;
    // Use this for initialization
    void Start () {
        boss = spawners[0].Spawn(team, chief);
	}

    // Update is called once per frame
    void Update()
    {
        if (Time.fixedTime - iniTime > intervalleSpawn)
        {
            foreach (SpawnEnemies element in spawners)
            {
                element.Spawn(this.team, characs);
            }
            iniTime = Time.fixedTime;
        }
        if (boss == null)
        {
            Destroy(this.gameObject);
        }
    }
}
