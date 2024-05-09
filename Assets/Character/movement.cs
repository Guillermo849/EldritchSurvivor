using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{

    private float speed;
    Rigidbody2D rgbd2d;
    Vector3 movementVector;
    private GameObject targetCharacter;

    // 
    private void Awake()
    {
        // Obtiene el valor de la velocidad del script "Character" y lo aplica a la variable local "speed"
        targetCharacter = GameObject.Find("PlayerCharacter");
        speed = targetCharacter.GetComponent<Character>().speed;
        
        // Se le aplica la posicion inicial y el codigo que le permitira moverse
        transform.position = new Vector3(0, 0, 0);
        rgbd2d = GetComponent<Rigidbody2D>();
        movementVector = new Vector3();
    }

    // Establece la velocidad del personaje y establece valores para los ejes x e y dependiendo que teclas de direccion estes presionando
    void Update()
    {
        speed = targetCharacter.GetComponent<Character>().speed;

        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        rgbd2d.velocity = movementVector * speed;
    }
}
