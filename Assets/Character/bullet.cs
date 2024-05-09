using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 mousePos;
    private GameObject targetCharacter;
    private Rigidbody2D rb;
    private float FORCE = 3;
    private int damage;
    [SerializeField] GameObject targedEnemy;

    // Once it's created it will travel through the angle between the character and where it aimed.
    // It will destroy itself after 10 seconds
    void Start()
    {
        targetCharacter = GameObject.Find("PlayerCharacter");
        damage = targetCharacter.GetComponent<Character>().damage;
        
        rb = GetComponent<Rigidbody2D>();
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * FORCE;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
        Destroy(gameObject, 10);
    }

    // If it comes in contact with the boss or enemy it will deal damage to them and destroy itself
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "boss")
        {
            collision.gameObject.GetComponent<BossBasic>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

}
