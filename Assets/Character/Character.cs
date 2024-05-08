using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    public int maxHp = 1000;
    public int currentHp = 1000;
    [SerializeField] StatusBar hpBar;
    public int damage = 5;
    public int speed = 3;
    public float attackSpeed = 1;
    [SerializeField] UpgradeManager upgradeManager;

    public void TakeDamage(int damage)
    {
        currentHp -= damage;

        if (currentHp < 0)
        {
            SceneManager.LoadScene("LooseScreen");
        }
        hpBar.SetState(currentHp, maxHp);
    }

    public void DamageUp(int cant)
    {
        damage += cant;
        upgradeManager.CloseMenu();
    }

    public void SpeedUp(int cant)
    {
        speed += cant;
        upgradeManager.CloseMenu();
    }

    public void AttackSpeedUp(float cant)
    {
       
        
        Debug.Log(attackSpeed);
        if (attackSpeed <= 0.4f) {
            Debug.LogWarning("Max amount of cadence reached");

        } else {
            attackSpeed -= cant;
            upgradeManager.CloseMenu();
        }
    }
}
