using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackTrigger : MonoBehaviour {

    public int dmg;
    public Character character;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger != true && collision.CompareTag("Damageable"))
        {
            collision.SendMessageUpwards("Damaged", new object[2] { dmg, character.team});
        }
    }
}
