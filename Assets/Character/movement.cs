using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{

    private float speed;
    Rigidbody2D rgbd2d;
    Vector3 movementVector;
    private GameObject targetCharacter;

    private void Awake()
    {
        targetCharacter = GameObject.Find("PlayerCharacter");
        speed = targetCharacter.GetComponent<Character>().speed;
        
        transform.position = new Vector3(0, 0, 0);
        rgbd2d = GetComponent<Rigidbody2D>();
        movementVector = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        speed = targetCharacter.GetComponent<Character>().speed;

        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        rgbd2d.velocity = movementVector * speed;
    }
}
