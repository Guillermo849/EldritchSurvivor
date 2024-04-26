using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    private GameObject targetCharacter;
    private Rigidbody2D rgbd2d;
    private float speed = 1.03f;
    public float distance = 3.0f;
    public float distanceToTeleport = 10.0f;
    [SerializeField] Transform teleportObject;
    private Transform teleportedObject;

    // Start is called before the first frame update
    void Start()
    {
        targetCharacter = GameObject.Find("PlayerCharacter");
        rgbd2d = GetComponent<Rigidbody2D>();
        teleportedObject = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (DistanceBetween() > distance)
        {
            Vector3 direction = (targetCharacter.GetComponent<Transform>().position - transform.position).normalized;
            rgbd2d.velocity = direction * speed;   
        } else
        {
            Vector3 direction = (targetCharacter.GetComponent<Transform>().position - transform.position).normalized;
            rgbd2d.velocity = direction * 0;
        }
        if (DistanceBetween() > distanceToTeleport)
        {
            teleportedObject.position = teleportObject.position;
        }
    }

    private float DistanceBetween()
    {
        float distance = Vector3.Distance (gameObject.transform.position, targetCharacter.transform.position);
        return distance;
    }
}
