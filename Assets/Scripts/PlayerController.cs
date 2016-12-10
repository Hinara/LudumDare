using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;

    public Camera camera;
    public Character character;
    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 vec = camera.ScreenToWorldPoint(Input.mousePosition);
            vec.z = 0;
            Quaternion quat = transform.rotation;
            quat.SetFromToRotation(Vector3.right, (vec - transform.position));
            transform.rotation = quat;
            character.Attack();
        }
        Vector2 temp = transform.position;
            if (Input.GetKey("up"))
                temp.y += speed;
            if (Input.GetKey("down"))
                temp.y -= speed;
            if (Input.GetKey("left"))
                temp.x -= speed;
            if (Input.GetKey("right"))
                temp.x += speed;
            transform.position = temp;
    }
}
