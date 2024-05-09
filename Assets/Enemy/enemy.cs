using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject targetCharacter;
    private float speed = 1.03f;
    private int maxHp = 10;
    private int currentHp;
    Rigidbody2D rgbd2d;
    private int DAMAGE = 1;
    [SerializeField] int experience_reward = 400;

    private void Awake() 
    {
        currentHp = maxHp;
        targetCharacter = GameObject.Find("PlayerCharacter");
        rgbd2d = GetComponent<Rigidbody2D>();
    }

    // Le asigna la direccion a la que dirigirse y la velocidad
    private void FixedUpdate() 
    {
        Vector3 direction = (targetCharacter.GetComponent<Transform>().position - transform.position).normalized;
        rgbd2d.velocity = direction * speed;
    }

    // Cuando el enemigo entra en contacto con el jugador llama a la funcion de atacar
    private void OnCollisionStay2D(Collision2D collision) 
    {
        if (collision.gameObject == targetCharacter)
        {
            Attack();
        }
    }

    // Funcion que provoca que el jugador reciba la cantidad de puntos de daño asignada a la variable "colisionDamage"
    private void Attack()
    {
        targetCharacter.GetComponent<Character>().TakeDamage(DAMAGE);   
    }

    // El enemigo recive la cantidad de daño pasada como parametro
    public void TakeDamage(int damage)
    {
        currentHp -= damage;
    }

    // Revisa constantemente que en enemigo no tiene vida para asi eliminarlo y otorgar la experiencia designada
    private void Update() {

        if (currentHp <= 0)
        {
            targetCharacter.GetComponent<Level>().AddExperience(experience_reward);
            Destroy(gameObject);
        }        
    }

    // Asigna la vida maxima del enemigo
    public void setMaxHp(int hp)
    {
        maxHp += hp;
        currentHp = maxHp;
    }

    // Asigna la velocidad del enemigo
    public void setSpeed(float extraSpeed)
    {
        speed += extraSpeed;
    }
}
