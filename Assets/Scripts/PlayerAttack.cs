using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private bool attacking = false;

    private float attackCd = 0.3f;
    private float attatckTime = 0f;

    public Collider2D attackTrigger;

    private void Awake()
    {
        attackTrigger.enabled = false;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0) && !attacking)
        {
            attacking = true;
            attatckTime = attackCd;

            attackTrigger.enabled = true;
        }
        else if (attacking)
        {
            if (attatckTime > 0)
            {
                attatckTime -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }
	}
}
