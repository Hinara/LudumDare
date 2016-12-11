using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Character : MonoBehaviour {

    public int minCoin;
    public int maxCoin;
    public int maxXp;
    public int minXp;
    public int life;
    public Rigidbody2D coin;
    public Rigidbody2D xp;
    public float immunityTime = 0.6f;
    private float immuneTime = 0.0f;
    private bool color_modified = false;
    private Color color;

    public Team team;

    /* For attack */
    private bool attacking = false;
    public float attackCd = 0.5f;
    public float attackDuration = 0.1f;
    private float attackTime = 0f;
    public Collider2D attackTrigger;

    private void Awake()
    {
        attackTrigger.enabled = false;
    }
    // Use this for initialization
    void Start ()
    {
        switch (this.team)
            {
            case Team.Flint:
                color = new Color(40.0f / 255.0f, 200.0f / 255.0f, 120.0f / 255.0f);
                break;
            case Team.Conner:
                color = new Color(255.0f / 255.0f, 215.0f / 255.0f, 0.0f / 255.0f);
                break;
            case Team.Kya:
                color = new Color(165.0f / 255.0f, 82.0f / 255.0f, 82.0f / 255.0f);
                break;
            case Team.Saria:
                color = new Color(200.0f / 255.0f, 255.0f / 45.0f, 255.0f / 255.0f);
                break;
            default:
                color = new Color(0.0f / 255.0f, 0.0f / 255.0f, 0.0f / 255.0f);
                break;
            }
        GetComponent<SpriteRenderer>().color = color;
    }
	// Update is called once per frame
	void Update () {
		if (immuneTime > 0.0f) // Immunité lors d'un coup reçu.
        {
            if (color_modified)
            {
                color_modified = false;
                GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 1F);
            }
            else
            {
                color_modified = true;
                GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 0.5F);
            }
            immuneTime -= Time.deltaTime;
            if (immuneTime <= 0.0f)
            {
                GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 1F);
            }
        }
    }

    void Damaged(object[] obj)
    {
        Debug.Log("NYAN");
        int dmg = (int) obj[0];
        Team team = (Team) obj[1];
        if (team != this.team)
        {
            if (immuneTime <= 0.0f)
            {
                life -= dmg;
                if (life < 0)
                {
                    int nbCoins = Random.Range(minCoin, maxCoin); // Generate coins...
                    for (int i = 0; i < nbCoins; i++)
                    {
                        float randomX = Random.Range(0.0f, 2.0f) - 1.0f;
                        float randomY = Random.Range(0.0f, 2.0f) - 1.0f;
                        Vector2 posCoin = new Vector2(transform.position.x + randomX, transform.position.y + randomY);
                        Instantiate(coin, posCoin, transform.rotation);
                    }
                    int nbXp = Random.Range(minXp, maxXp); // ... and xp
                    for (int i = 0; i < nbXp; i++)
                    {
                        float randomX = Random.Range(0.0f, 2.0f) - 1.0f;
                        float randomY = Random.Range(0.0f, 2.0f) - 1.0f;
                        Vector2 posXp = new Vector2(gameObject.transform.position.x + randomX, transform.position.y + randomY);
                        Instantiate(xp, posXp, transform.rotation);
                    }
                    Destroy(gameObject);
                }
                immuneTime = immunityTime;
            }
        }
    }

    public void Attack()
    {
        if (!attacking)
        {
            attacking = true;
            attackTime = attackCd;
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
                attacking = false;
            }
        }
    }

    public void CharacterSpawn(Vector2 position)
    {
        Instantiate(gameObject, position, transform.rotation);
    }
}
