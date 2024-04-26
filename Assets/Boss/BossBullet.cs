using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public Vector3 rotationPoint;
    public Vector3 centerPoint;
    private int FORCE = 3;
    public int damage = 50;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rotationPoint = GameObject.Find("BossBulletTransform").transform.position;
        centerPoint = GameObject.Find("BossRotatePoint").transform.position;
        Vector3 direction = rotationPoint - centerPoint;
        Vector3 rotation = centerPoint - rotationPoint;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * FORCE;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
        Destroy(gameObject, 10);
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Character>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
