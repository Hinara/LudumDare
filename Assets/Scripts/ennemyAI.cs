using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemyAI : MonoBehaviour
{
    protected Character parent;
    protected Character target;
    public MinonType type;

    public float speed = 0.0f;
    // Use this for initialization
    protected void Awake()
    {
        parent = GetComponentInParent<Character>();
        target = null;
    }

    private void Update()
    {
        if (target != null)
        {
            if (target.gameObject == null)
            {
                target = null;
            }
            else if (type == MinonType.Swordman && !parent.isAttacking() && Vector2.Distance(target.transform.position, parent.transform.position) < 0.5f && !target.isInvincible())
            {
                Quaternion quat = transform.rotation;
                quat.SetFromToRotation(Vector3.right, (target.transform.position - transform.position));
                transform.rotation = quat;
                parent.Attack();
            }
            else if (type == MinonType.Spearman && !parent.isAttacking() && Vector2.Distance(target.transform.position, parent.transform.position) < 1.0f && !target.isInvincible())
            {
                Quaternion quat = transform.rotation;
                quat.SetFromToRotation(Vector3.right, (target.transform.position - transform.position));
                transform.rotation = quat;
                parent.Attack();
            }
            else if (type == MinonType.Archer)
            {
                if (Vector2.Distance(target.transform.position, parent.transform.position) < 0.5f)
                {
                    Quaternion quat = transform.rotation;
                    quat.SetFromToRotation(Vector3.right, (target.transform.position - transform.position));
                    transform.rotation = quat;
                    parent.Attack();
                }
                else if (Vector2.Distance(target.transform.position, parent.transform.position) < 2.5f)
                {
                    Quaternion quat = transform.rotation;
                    quat.SetFromToRotation(Vector3.right, (target.transform.position - transform.position));
                    transform.rotation = quat;
                    parent.RangeAttack(target.transform.position);
                }
                else
                {
                    Quaternion quat = transform.rotation;
                    quat.SetFromToRotation(Vector3.right, (target.transform.position - transform.position));
                    transform.rotation = quat;
                    Vector2 temp = transform.position;
                    temp.y = temp.y + (Mathf.Sin(quat.eulerAngles.z) * 0.02f);
                    temp.x = temp.x + (Mathf.Cos(quat.eulerAngles.z) * 0.02f);
                    transform.position = temp;
                }
            }
            else
            {
                Quaternion quat = transform.rotation;
                quat.SetFromToRotation(Vector3.right, (target.transform.position - transform.position));
                transform.rotation = quat;
                Vector2 temp = transform.position;
                temp.y = temp.y + (Mathf.Sin(quat.eulerAngles.z) * 0.02f);
                temp.x = temp.x + (Mathf.Cos(quat.eulerAngles.z) * 0.02f);
                transform.position = temp;
            }
        }
        else
        {
            Quaternion quat = transform.rotation;
            quat.SetFromToRotation(Vector3.right, -transform.position);
            transform.rotation = quat;
            Vector2 temp = transform.position;
            temp.y = temp.y + (Mathf.Sin(quat.eulerAngles.z) * 0.02f);
            temp.x = temp.x + (Mathf.Cos(quat.eulerAngles.z) * 0.02f);
            transform.position = temp;
        }
    }
    public void setTarget(Character target)
    {
        this.target = target;
    }
    public Character getTarget()
    {
        return (this.target);
    }

    private void returnValueImportant(Character charac)
    {
        int value;
    }

    public Character closestEnnemy()
    {
        GameObject[] damageable;
        damageable = GameObject.FindGameObjectsWithTag("Damageable");
        Character closest;
        closest = null;
        foreach (GameObject obj in damageable)
        {
            Character chara;
            chara = obj.GetComponent<Character>();
            if (chara != null)
            {
                if (chara.team != parent.team)
                {
                    if (closest != null)
                    {
                        if (Vector2.Distance(gameObject.transform.position, chara.gameObject.transform.position) <
                            Vector2.Distance(gameObject.transform.position, closest.gameObject.transform.position))
                        {
                            closest = chara;
                        }
                    }
                    else
                    {
                        closest = chara;
                    }
                }
            }
        }

        return closest;
    }
}
