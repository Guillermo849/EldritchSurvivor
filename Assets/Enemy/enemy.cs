using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.TextCore.Text;
using Debug = UnityEngine.Debug;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform targetDestination;
    GameObject targetGameObject;
    [SerializeField]Character targedCharacter;
    private float SPEED = 1.03f;

    public int maxHp = 20;

    public int currentHp = 20;

    Rigidbody2D rgbd2d;

    [SerializeField] int damage = 1;

    private void Awake() 
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        targetGameObject = targetDestination.gameObject;
    }

    private void FixedUpdate() 
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rgbd2d.velocity = direction * SPEED;
    }

    private void OnCollisionStay2D(Collision2D collision) 
    {
        if (collision.gameObject == targetGameObject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        targedCharacter.TakeDamage(damage);   
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
    }

    private void Update() {

        if (currentHp <= 0)
        {
            Debug.LogWarning("Enemigo eliminado");
            Destroy(gameObject);
        }        
    }
}
