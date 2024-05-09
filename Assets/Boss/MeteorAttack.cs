using System.Collections;
using UnityEngine;

public class MeteorAttack : MonoBehaviour
{
    private int DAMAGE = 200;
    
    public void Start() {
        StartCoroutine(Strike());
    }

    // It moves to the current character postion and stay there until it finishes it's loop
    private IEnumerator Strike(){
        Vector3 originalSize = gameObject.transform.localScale;
        for (int i = 0; i < 3; i++) {
            yield return new WaitForSeconds(0.3f);
            gameObject.transform.localScale = new Vector3(originalSize.x-3f, originalSize.y-3f, 0);
        }
        gameObject.transform.localScale = originalSize;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(0.7f);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Destroy(gameObject);
    }

    // It deals damage to the charater once when it comes to in contact with it for the first time
     public void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Character>().TakeDamage(DAMAGE);
            Debug.Log("Took damage");
        }
    }
}
