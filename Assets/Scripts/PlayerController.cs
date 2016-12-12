using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private float speed;

    public Camera camera;
    public Character character;
    // Use this for initialization
    void Start () {
        speed = character.getSpeed();
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
        else if (Input.GetMouseButtonDown(1))
        {
            Vector3 vec = camera.ScreenToWorldPoint(Input.mousePosition);
            vec.z = 0;
            Quaternion quat = transform.rotation;
            quat.SetFromToRotation(Vector3.right, (vec - transform.position));
            transform.rotation = quat;
            character.RangeAttack(vec);
        }
        Vector2 temp = transform.position;
            if (Input.GetKey("z"))
                temp.y += speed;
            if (Input.GetKey("s"))
                temp.y -= speed;
            if (Input.GetKey("q"))
                temp.x -= speed;
            if (Input.GetKey("d"))
                temp.x += speed;
            transform.position = temp;
    }
}
