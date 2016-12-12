using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemiDetection : MonoBehaviour {

    Character my_chara;
    ennemyAI ai;
    int value = -1;
    private void Awake()
    {
        my_chara = this.GetComponentInParent<Character>();
        ai = this.GetComponentInParent<ennemyAI>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        OnTriggerEnter2D(collision);
    }

    private int returnValueImportant(Character charac, Character me)
    {
        if (pTeam(me, charac) == -1)
            return (-1);
        int value = pTeam(me, charac) + charac.getLifePurcentage();
        return (1);
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
                if (my_chara.team != chara.team && returnValueImportant(chara, my_chara) != -1)
                {
                    if (ai.getTarget() != null)
                    {
                        if (returnValueImportant(chara, my_chara) > value)
                        {
                            value = returnValueImportant(chara, my_chara);
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
                value = -1;
            }
        }
    }

   private int pTeam(Character charac, Character enemy)
    {
        const int friend = -1;
        const int neutral = 0;
        const int ennemy = 50;
        const int worst = 100;
        switch (charac.getTeam())
        {
            case Team.Conner:
                if (enemy.isPlayer())
                    return enemy.getRelationConner();
                if (enemy.getTeam() == Team.Conner)
                    return (friend);
                if (enemy.getTeam() == Team.Flint)
                    return (ennemy);
                if (enemy.getTeam() == Team.Kya)
                    return (neutral);
                if (enemy.getTeam() == Team.Saria)
                    return (neutral);
                break;

            case Team.Flint:
                if (enemy.isPlayer())
                    return enemy.getRelationFlint();
                if (enemy.getTeam() == Team.Conner)
                    return (ennemy);
                if (enemy.getTeam() == Team.Flint)
                    return (friend);
                if (enemy.getTeam() == Team.Kya)
                    return (worst);
                if (enemy.getTeam() == Team.Saria)
                    return (worst);
                break;

            case Team.Kya:
                if (enemy.isPlayer())
                    return enemy.getRelationKya();
                if (enemy.getTeam() == Team.Conner)
                    return (neutral);
                if (enemy.getTeam() == Team.Flint)
                    return (worst);
                if (enemy.getTeam() == Team.Kya)
                    return (friend);
                if (enemy.getTeam() == Team.Saria)
                    return (friend);
                break;

            case Team.Saria:
                if (enemy.isPlayer())
                    return enemy.getRelationSaria();
                if (enemy.getTeam() == Team.Conner)
                    return (neutral);
                if (enemy.getTeam() == Team.Flint)
                    return (ennemy);
                if (enemy.getTeam() == Team.Kya)
                    return (friend);
                if (enemy.getTeam() == Team.Saria)
                    return (friend);
                break;
        }
        return (-1);
    }
}
