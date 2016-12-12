using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackTrigger : MonoBehaviour {

    Character character;

    private void Awake()
    {
        character = GetComponentInParent<Character>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Damageable"))
        {
            collision.SendMessageUpwards("Damaged", character);
        }
    }
}
