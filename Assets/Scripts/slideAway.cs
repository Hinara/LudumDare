using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slideAway : MonoBehaviour {
    public float speed;
    public float frottement;
    private float angle;
	// Use this for initialization
	void Start () {
		angle = Random.Range(0.0f, 2 * Mathf.PI);
    }
	
	// Update is called once per frame
	void Update () {
        if (speed > 0)
        {
            Vector2 newPos = new Vector2(this.gameObject.transform.position.x + Mathf.Cos(angle), this.gameObject.transform.position.y + Mathf.Sin(angle));
            transform.position = newPos * speed;
            speed -= frottement;
        }
        else
            Destroy(gameObject);
	}
}
