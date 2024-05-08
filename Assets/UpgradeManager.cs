using UnityEngine;

public class UpgradeManager : MonoBehaviour
{

    [SerializeField] GameObject panel;
    PauseManager pauseManager;

    private void Awake() {
        pauseManager = GetComponent<PauseManager>();
    }

    public void CloseMenu()
    {
        pauseManager.UnPauseGame();
        panel.SetActive(false);
    }

    public void OpenMenu()
    {
        pauseManager.PauseGame();
        panel.SetActive(true);
    }
    
}
