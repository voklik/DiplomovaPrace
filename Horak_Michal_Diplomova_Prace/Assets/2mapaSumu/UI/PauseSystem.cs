using UnityEngine;
using UnityEngine.UI;

public class PauseSystem : MonoBehaviour
{
    //T��da, kter� za�izuje pauzov�n� a odpauzov�n� prob�haj�c� simulace
    bool isPaused = false;

    [SerializeField] Text text;

    public void PauseResumeTime()
    {
        if (isPaused) { ResumeGame(); }
        else PauseGame();
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        text.text = "Unpause simulation";
        isPaused = !isPaused;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        text.text = "Pause simulation";
        isPaused = !isPaused;
    }
}
