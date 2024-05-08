using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLooseScreen : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
