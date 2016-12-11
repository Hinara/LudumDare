using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayOnPoint : MonoBehaviour {
    private Vector2 cible;
    public Character charac;
    private float speed;
    // Use this for initialization
    void Start () {
		cible = transform.position;
        speed = charac.getSpeed();
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 temp = transform.position;
        Debug.Log(transform.position.y);
        if (Mathf.Abs(cible.y - transform.position.y) > 0.1f)
        {
            if (cible.y > transform.position.y)
                temp.y += speed;
            if (cible.y < transform.position.y)
                temp.y -= speed;
        }
        if (Mathf.Abs(cible.x - transform.position.x) > 0.1f)
        {
            if (cible.x < transform.position.x)
                temp.x -= speed;
            if (cible.x > transform.position.x)
                temp.x += speed;
        }
        transform.position = temp;
    }
}
