using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    Character chara;
    public float ttl = 3.0f;
    public int dmg = 25;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        /*if (collision.gameObject.GetComponent<Projectile>() != null)
        {
            Destroy(collision.gameObject);
        }*/
        if (collider.CompareTag("Damageable"))
        {
            if (this.chara != null && this.chara.gameObject != null && 
                collider.gameObject.GetInstanceID() != this.chara.gameObject.GetInstanceID())
            {
                collider.SendMessageUpwards("Damaged", new object[2] { dmg, chara.team });
                Destroy(this.gameObject);
            }
        }
    }

    public void setLauncher(Character chara)
    {
        this.chara = chara;
    }
    public Character getLauncher()
    {
        return (chara);
    }
    // Update is called once per frame
    void Update () {
        ttl -= Time.deltaTime;
        if (ttl <= 0.0f)
        {
            Destroy(this.gameObject);
        }
	}
}
