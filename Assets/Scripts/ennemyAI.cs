using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemyAI : MonoBehaviour
{
    protected Character parent;
    protected Character target;
    protected Character ally;
    public MinonType type;

    public float speed = 0.0f;
    // Use this for initialization
    protected void Awake()
    {
        parent = GetComponentInParent<Character>();
        target = null;
        ally = null;
    }

    private void rotateInDirection (Vector3 vec)
    {
        Quaternion quat = transform.rotation;
        quat.SetFromToRotation(Vector3.right, (vec - transform.position));
        transform.rotation = quat;
    }

    private void moveForward()
    {
        Vector2 temp = transform.position;
        temp.y = temp.y + (Mathf.Sin(transform.rotation.eulerAngles.z) * speed);
        temp.x = temp.x + (Mathf.Cos(transform.rotation.eulerAngles.z) * speed);
        transform.position = temp;
    }
    private void moveBackward()
    {
        transform.rotation = Quaternion.Inverse(transform.rotation);
        Vector2 temp = transform.position;
        temp.y = temp.y - (Mathf.Sin(transform.rotation.eulerAngles.z) * speed);
        temp.x = temp.x - (Mathf.Cos(transform.rotation.eulerAngles.z) * speed);
        transform.position = temp;
        transform.rotation = Quaternion.Inverse(transform.rotation);
    }

    private void Update()
    {
        if (ally != null && this.type == MinonType.Healer)
        {
            if (ally.getLifePurcentage() >= 100)
            {
                ally = null;
                if (target != null && Vector2.Distance(target.transform.position, parent.transform.position) < 1.0f)
                {
                    rotateInDirection(target.transform.position);
                    moveBackward();
                }
                else
                {
                    moveForward();
                }
            }
            else
            {
                if (Vector2.Distance(ally.transform.position, parent.transform.position) < 1.0f)
                {
                    rotateInDirection(ally.transform.position);
                    if (!parent.isAttacking())
                    {
                        parent.Attack();
                    }
                }
                else
                {
                    if (target != null && Vector2.Distance(ally.transform.position, parent.transform.position) < 1.0f)
                    {
                        rotateInDirection(target.transform.position);
                        moveBackward();
                    }
                    else
                    {
                        moveForward();
                    }
                }
            }
        }
        else if (target != null)
        {
            if (target.gameObject == null)
            {
                target = null;
            }
            else
            {
                rotateInDirection(target.transform.position);
                switch (this.type)
                {
                    case MinonType.Swordman:
                        if (Vector2.Distance(target.transform.position, parent.transform.position) < 0.8f)
                        {
                            if (!parent.isAttacking() && !target.isInvincible())
                            {
                                parent.Attack();
                            }
                        }
                        else
                        {
                            moveForward();
                        }
                        break;
                    case MinonType.Spearman:
                        if (Vector2.Distance(target.transform.position, parent.transform.position) < 1.0f)
                        {
                            if (!parent.isAttacking() && !target.isInvincible())
                            {
                                parent.Attack();
                            }
                        }
                        else
                        {
                            moveForward();
                        }
                        break;
                    case MinonType.Archer:
                        if (Vector2.Distance(target.transform.position, parent.transform.position) < 1f)
                        {
                            moveBackward();
                        }
                        else if (Vector2.Distance(target.transform.position, parent.transform.position) < 3f)
                        {
                            parent.RangeAttack(target.transform.position);
                        }
                        else
                        {
                            moveForward();
                        }
                        break;
                    case MinonType.Healer:
                        if (Vector2.Distance(target.transform.position, parent.transform.position) < 1.0f)
                        {
                            moveBackward();
                        }
                        else
                        {
                            rotateInDirection(Vector3.zero);
                            moveForward();
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        else
        {
            rotateInDirection(Vector3.zero);
            moveForward();
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
    public void setAlly(Character ally)
    {
        this.ally = ally;
    }
    public Character getAlly()
    {
        return (this.ally);
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
