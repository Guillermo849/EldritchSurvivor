using UnityEngine;

public class BossMovement : MonoBehaviour
{
    private GameObject targetCharacter;
    private Rigidbody2D rgbd2d;
    private float speed = 2.03f;
    public float distance = 3.0f;
    public float distanceToTeleport = 10.0f;
    Transform teleportObject;
    private Transform teleportedObject;

    // Start is called before the first frame update
    void Start()
    {
        targetCharacter = GameObject.Find("PlayerCharacter"); 
        rgbd2d = GetComponent<Rigidbody2D>();
        teleportObject = GameObject.Find("Generator").transform;
        teleportedObject = gameObject.transform;
    }

    // Funcion que esta constantemente llamando a la funcion "DistanceBetween" y si es mayor a la cantidad de la variable "distance" se dirije a la posicion del jugador, 
    // pero si la distancia es menor el boss se queda quieto
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

    // Funcion que devuelve la distancia ente el jugador y el boss
    private float DistanceBetween()
    {
        float distance = Vector3.Distance (gameObject.transform.position, targetCharacter.transform.position);
        return distance;
    }
}
