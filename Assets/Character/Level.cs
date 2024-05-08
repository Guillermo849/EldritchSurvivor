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

    int TO_LEVEL_UP
    {
        get 
        { 
            return level * 1000;
        }
    }

    public void AddExperience(int cant)
    {
        experience += cant;
        CheckLevelUp();
    }

    public void CheckLevelUp()
    {
        if (experience >= TO_LEVEL_UP)
        {
            LevelUp();
        }
        xPbar.SetState(experience, TO_LEVEL_UP);
    }

    private void LevelUp()
    {
        upgradeManager.OpenMenu();
        experience -= TO_LEVEL_UP;
        level += 1;
    }
}
