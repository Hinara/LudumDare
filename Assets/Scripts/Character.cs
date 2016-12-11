using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Character : MonoBehaviour {
    [Tooltip("Minimum coins the character can drop.")]
    public int minCoin;
    [Tooltip("Maximum coins the character can drop.")]
    public int maxCoin;
    [Tooltip("Minimum xp the character can drop.")]
    public int minXp;
    [Tooltip("Maximum xps the character can drop.")]
    public int maxXp;
    [Tooltip("Character's life.")]
    public int life;
    [Tooltip("Rigidbody of the coin.")]
    public Rigidbody2D coin;
    [Tooltip("Rigidbody of the xp.")]
    public Rigidbody2D xp;
    [Tooltip("The time the character is immortal after being hurt.")]
    public float immunityTime = 0.6f;
    private float immuneTime = 0.0f;
    private bool color_modified = false;
    private Color color;
    [Tooltip("Speed of the character.")]
    public float speed;

    [Tooltip("The team the character belong to")]
    public Team team;

    /* For attack */
    private bool attacking = false;
    [Tooltip("Cooldown between 2 attacks.")]
    public float attackCd = 0.5f;
    [Tooltip("Cooldown between 2 attacks for range attack.")]
    public float attackRangeCd = 2f;
    [Tooltip("Attack duration.")]
    public float attackDuration = 0.1f;
    private float attackTime = 0f;
    [Tooltip("Collider 2D of the hit detection.")]
    public Collider2D attackTrigger;
    [Tooltip("Projectile shot by the entity")]
    public Projectile projectile;

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
        if (attacking)
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

    void Damaged(object[] obj)
    {
        int dmg = (int) obj[0];
        Team team = (Team) obj[1];
        if (true)// team != this.team)
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
        print("Attack");
        if (!attacking)
        {
            print("Attack2");
            attacking = true;
            attackTime = attackCd;
            attackTrigger.enabled = true;
        }
    }

    public void RangeAttack(Vector2 targetPos)
    {
        if (!attacking)
        {
            Vector2 targetDir = (targetPos - ((Vector2)transform.position));
            GameObject obj;
            Rigidbody2D rb;
            obj = Instantiate(projectile.gameObject, transform.position, transform.rotation) as GameObject;
            obj.GetComponent<Projectile>().setLauncher(this);
            rb = obj.GetComponent<Rigidbody2D>();
            rb.velocity = targetDir.normalized * 20.0f;
            //rb.AddForce(temp, ForceMode2D.Impulse);
            attacking = true;
            attackTime = attackRangeCd;
        }
    }

    public GameObject CharacterSpawn(Vector2 position)
    {
        return (Instantiate(gameObject, position, transform.rotation));
    }

    public float getSpeed()
    {
        return (speed);
    }
    public bool isAttacking()
    {
        return (this.attacking);
    }
    public bool isInvincible()
    {
        return (this.immuneTime > 0.0f);
    }
}
