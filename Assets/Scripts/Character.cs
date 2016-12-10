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
	// Use this for initialization
	void Start () {
        color = GetComponent<SpriteRenderer>().color;
    }
	// Update is called once per frame
	void Update () {
		if (immuneTime > 0.0f)
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

    void Damaged(int dmg)
    {
        if (immuneTime <= 0.0f)
        { 
          life -= dmg;
          if (life < 0)
            {
            int nbCoins = Random.Range(minCoin, maxCoin);
            for (int i = 0; i < nbCoins; i++)
            {
                float randomX = Random.Range(0.0f, 2.0f) - 1.0f;
                float randomY = Random.Range(0.0f, 2.0f) - 1.0f;
                Vector2 posCoin = new Vector2(transform.position.x + randomX, transform.position.y + randomY);
                Rigidbody2D coinClone = (Rigidbody2D)Instantiate(coin, posCoin, transform.rotation);
            }
            }
          immuneTime = immunityTime;
        }
    }
}
