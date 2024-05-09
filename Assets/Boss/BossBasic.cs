using UnityEngine;
using UnityEngine.SceneManagement;

public class BossBasic : MonoBehaviour
{
    private int maxHp = 1500;
    public int currentHp;
    private GameObject targetCharacter;
    private int colisionDamage = 2;
    [SerializeField] BossStatusBar hpBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        targetCharacter = GameObject.Find("PlayerCharacter");
    }

    // Cuando el boss entra en contacto con el jugador llama a la funcion de atacar
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
        targetCharacter.GetComponent<Character>().TakeDamage(colisionDamage);   
    }

    // Funcion que provoca que el boss reciba la cantidad de daño pasada como parametro
    public void TakeDamage(int damage)
    {
        currentHp -= damage;

        if (currentHp <= 0)
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene("WinScreen");
        }
        hpBar.SetState(currentHp, maxHp);
    }
}
