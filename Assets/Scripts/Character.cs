using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    public int minCoin;
    public int maxCoin;
    public int minXp;
    public int maxXp;
    public int life;
    public Rigidbody2D coin;
    public Rigidbody2D xp;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Damaged(int dmg)
    {
        life -= dmg;
        print(life);
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
            int nbXp = Random.Range(minXp, maxXp);
            for (int i = 0; i < nbXp; i++)
            {
                float randomX = Random.Range(0.0f, 2.0f) - 1.0f;
                float randomY = Random.Range(0.0f, 2.0f) - 1.0f;
                Vector2 posXp = new Vector2(transform.position.x + randomX, transform.position.y + randomY);
                Rigidbody2D xpClone = (Rigidbody2D)Instantiate(xp, posXp, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
