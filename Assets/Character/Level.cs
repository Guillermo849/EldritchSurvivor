using UnityEngine;

public class Level : MonoBehaviour
{
    int experience = 0;
    int level = 1;
    [SerializeField] XPbar xPbar;
    private GameObject targetCharacter;
    [SerializeField] UpgradeManager upgradeManager;

    private void Awake() {
        targetCharacter = GameObject.Find("PlayerCharacter");
    }

    // Se declara una variable que aumenta su valor cada vez que es llamada
    int TO_LEVEL_UP
    {
        get 
        { 
            return level * 1000;
        }
    }

    // Añade una cantidad pasada como parametro a la experiencia total del personaje
    public void AddExperience(int cant)
    {
        experience += cant;
        CheckLevelUp();
    }

    // Comprueva si es posible subir de nivel
    public void CheckLevelUp()
    {
        if (experience >= TO_LEVEL_UP)
        {
            LevelUp();
        }
        xPbar.SetState(experience, TO_LEVEL_UP);
    }

    // Sube de nivel al personaje
    private void LevelUp()
    {
        upgradeManager.OpenMenu();
        experience -= TO_LEVEL_UP;
        level += 1;
    }
}
