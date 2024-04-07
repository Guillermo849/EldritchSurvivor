using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class movement : MonoBehaviour
{

    Rigidbody2D rgbd2d;
    Vector3 movementVector;

    private void Awake()
    {
        transform.position = new Vector3(0, 0, 0);
        rgbd2d = GetComponent<Rigidbody2D>();
        movementVector = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        rgbd2d.velocity = movementVector;
    }
}
