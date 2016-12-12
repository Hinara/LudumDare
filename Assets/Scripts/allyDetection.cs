using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allyDetection : MonoBehaviour {

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
                //Verify thath the ennemy is from the same team
                if (my_chara.team == chara.team)
                {
                    if (ai.getAlly() != null)
                    {
                        if (chara.getLifePurcentage() < ai.getAlly().getLifePurcentage())
                        {
                            ai.setAlly(chara);
                        }
                    }
                    else
                    {
                        ai.setAlly(chara);
                    }
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (ai.getAlly() != null && collision.GetComponent<Character>() != null)
        {
            if (ai.getAlly().gameObject.GetInstanceID() == collision.GetComponent<Character>().gameObject.GetInstanceID())
            {
                ai.setAlly(null);
            }
        }
    }
}
