using UnityEngine;

public class Enemy : MonoBehaviour
{
    //[SerializeField] Transform targetDestination;
    GameObject targetCharacter;
    //[SerializeField]Character targedCharacter;
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

    private void FixedUpdate() 
    {
        Vector3 direction = (targetCharacter.GetComponent<Transform>().position - transform.position).normalized;
        rgbd2d.velocity = direction * speed;
    }

    private void OnCollisionStay2D(Collision2D collision) 
    {
        if (collision.gameObject == targetCharacter)
        {
            Attack();
        }
    }

    private void Attack()
    {
        targetCharacter.GetComponent<Character>().TakeDamage(DAMAGE);   
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
    }

    private void Update() {

        if (currentHp <= 0)
        {
            targetCharacter.GetComponent<Level>().AddExperience(experience_reward);
            Destroy(gameObject);
        }        
    }

    public void setMaxHp(int hp)
    {
        maxHp += hp;
        currentHp = maxHp;
    }

    public void setSpeed(float extraSpeed)
    {
        speed += extraSpeed;
    }
}
