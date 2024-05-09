using UnityEngine;

public class BossStatusBar : MonoBehaviour
{
    [SerializeField] Transform bar;


    // Funcion que hace que la barra de vida del boss se actualice y sea funcional
    public void SetState(int current, int max) 
    {
        float state = (float)current;
        state /= max;
        if (state < 0f) { state = 0f; }
        bar.transform.localScale = new Vector3(state, 1f, 1f);
    }
}
