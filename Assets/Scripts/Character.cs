using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    public int life;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Damaged(int dmg)
    {
        life -= dmg;
        print(life);
        if (life < 0)
        {
            Destroy(gameObject);
        }
    }
}
