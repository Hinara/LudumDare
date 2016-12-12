using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healTrigger : MonoBehaviour {

    Character character;

    private void Awake()
    {
        character = GetComponentInParent<Character>();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        OnTriggerEnter2D(collision);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Damageable"))
        {
            print("Heal");
            Character collider = collision.GetComponent<Character>();
            if (collider.team == character.team)
            {
                collision.SendMessageUpwards("Healed", character);
            }
        }
    }
}
