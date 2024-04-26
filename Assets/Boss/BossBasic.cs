using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBasic : MonoBehaviour
{
    private int maxHp = 150;
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

    private void OnCollisionStay2D(Collision2D collision) 
    {
        if (collision.gameObject == targetCharacter)
        {
            Attack();
        }
    }

    private void Attack()
    {
        targetCharacter.GetComponent<Character>().TakeDamage(colisionDamage);   
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;

        if (currentHp <= 0)
        {
            gameObject.SetActive(false);
            Debug.LogWarning("Jefe eliminado, Has ganado!!!");
        }
        hpBar.SetState(currentHp, maxHp);
    }
}
