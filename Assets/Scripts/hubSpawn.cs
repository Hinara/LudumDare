using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hubSpawn : MonoBehaviour {
    public Team team;
    public SpawnEnemies[] spawners;
    [Tooltip("Intervalle between each enemies spawn in secondes.")]
    public float intervalleSpawn;
    private float iniTime;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Time.fixedTime - iniTime > intervalleSpawn)
        {
            foreach (SpawnEnemies element in spawners)
            {
                element.Spawn(this.team);
            }
            iniTime = Time.fixedTime;
        }
    }
}
