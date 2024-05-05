using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHp = 1000;
    public int currentHp = 1000;
    [SerializeField] StatusBar hpBar;
    public int damage = 5;
    public int speed = 5;
    public float attackSpeed = 1;
    [SerializeField] UpgradeManager upgradeManager;

    public void TakeDamage(int damage)
    {
        currentHp -= damage;

        if (currentHp < 0)
        {
            Debug.LogWarning("Has morido GAME OVER");
            Time.timeScale = 0;
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
        if (attackSpeed == 0.2f)
            {
                Debug.LogWarning("Max amount of cadence reached");
            }
            else
                {
                    attackSpeed -= cant;
                    upgradeManager.CloseMenu();
                }
    }
}
