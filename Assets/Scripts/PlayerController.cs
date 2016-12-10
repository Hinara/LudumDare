using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 temp = this.gameObject.transform.position;
        if (Input.GetKey("up"))
            temp.y += speed;
        if (Input.GetKey("down"))
            temp.y -= speed;
        if (Input.GetKey("left"))
            temp.x -= speed;
        if (Input.GetKey("right"))
            temp.x += speed;
        this.gameObject.transform.position = temp;
    }
}
