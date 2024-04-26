using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorAttack : MonoBehaviour
{
    private int DAMAGE = 200;
    
     public void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Character>().TakeDamage(DAMAGE);
        }
    }
}
