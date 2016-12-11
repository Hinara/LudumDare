using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemiDetection : MonoBehaviour {

    Character my_chara;
    ennemyAI ai;
    private void Awake()
    {
        my_chara = this.GetComponentInParent<Character>();
        ai = this.GetComponentInParent<ennemyAI>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        OnTriggerEnter2D(collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger != true && collision.CompareTag("Damageable"))
        {
            Character chara;
            chara = collision.GetComponent<Character>();
            if (chara != null)
            {
                //Verify thath the ennemy is from a diffrent team
                if (my_chara.team != chara.team)
                {
                    if (ai.getTarget() != null)
                    {
                        if (Vector2.Distance(my_chara.transform.position, chara.transform.position) <
                            Vector2.Distance(my_chara.transform.position, ai.getTarget().transform.position))
                        {
                            ai.setTarget(chara);
                        }
                    }
                    else
                    {
                        ai.setTarget(chara);
                    }
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (ai.getTarget() != null && collision.GetComponent<Character>() != null)
        {
            if (ai.getTarget().gameObject.GetInstanceID() == collision.GetComponent<Character>().gameObject.GetInstanceID())
            {
                ai.setTarget(null);
            }
        }
    }
}
