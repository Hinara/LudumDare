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
        if (target != null)
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
}
