using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private float speed;

    public Camera cam;
    public Character character;

    private void Awake()
    {
         GameObject obj= GameObject.FindGameObjectWithTag("Store");
        if (obj != null)
        {
            print("ok");
            character.team = obj.GetComponent<Store>().getTeam();
            Destroy(obj);
        }
        print("ko");
    }

    // Use this for initialization
    void Start () {
        speed = character.getSpeed();
    }

    // Update is called once per frame
    private void Update()
    {
        //Attack
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 vec = cam.ScreenToWorldPoint(Input.mousePosition);
            vec.z = 0;
            Quaternion quat = transform.rotation;
            quat.SetFromToRotation(Vector3.right, (vec - transform.position));
            transform.rotation = quat;
            character.Attack();
        }
        //Bow
        else if (Input.GetButtonDown("Fire2"))
        {
            Vector3 vec = cam.ScreenToWorldPoint(Input.mousePosition);
            vec.z = 0;
            Quaternion quat = transform.rotation;
            quat.SetFromToRotation(Vector3.right, (vec - transform.position));
            transform.rotation = quat;
            character.RangeAttack(vec);
        }
        //Movement
        Vector2 temp = transform.position;
            if (Input.GetButton("Up"))
                temp.y += speed;
            if (Input.GetButton("Down"))
                temp.y -= speed;
            if (Input.GetButton("Left"))
                temp.x -= speed;
            if (Input.GetButton("Right"))
                temp.x += speed;
            transform.position = temp;
    }
}
