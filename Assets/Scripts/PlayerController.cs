using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;
    private bool attacking = false;

    public float attackCd = 0.5f;
    public float attackDuration = 0.1f;
    private float attackTime = 0f;

    public Collider2D attackTrigger;
    // Use this for initialization
    void Start () {
    }

    private void Awake()
    {
        attackTrigger.enabled = false;
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !attacking)
        {
            attacking = true;
            attackTime = attackCd;
            print(attackCd);
            attackTrigger.enabled = true;
        }
        else if (attacking)
        {
            if (attackTrigger.enabled && (attackTime <= (attackCd - attackDuration)))
            {
                attackTrigger.enabled = false;
            }
            if (attackTime >= 0f)
            {
                attackTime -= Time.deltaTime;
            }
            else
            {
                print("End cooldown");
                attacking = false;
            }
        }
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
