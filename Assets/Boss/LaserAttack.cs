using System.Collections;
using UnityEngine;

public class LaserAttack : MonoBehaviour
{
    private int DAMAGE = 10;
    
     public void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Player")
        {
            StartCoroutine(DamageDelt(other));
        }
    }

    private IEnumerator DamageDelt(Collider2D player){
        player.gameObject.GetComponent<Character>().TakeDamage(DAMAGE);
        yield return new WaitForSeconds(0.2f);
    }
}
