using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHp = 1000;
    public int currentHp = 1000;
    [SerializeField] StatusBar hpBar;

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
}