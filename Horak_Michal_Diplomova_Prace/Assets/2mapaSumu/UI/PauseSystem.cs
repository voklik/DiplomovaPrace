using UnityEngine;
using UnityEngine.UI;

public class PauseSystem : MonoBehaviour
{
    //Tøída, která zaøizuje pauzování a odpauzování probíhající simulace
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
        text.text = CaptionsLibrary.GetCaption("UnpauseSimulation");
        isPaused = !isPaused;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        text.text = CaptionsLibrary.GetCaption("PauseSimulation");
        isPaused = !isPaused;
    }
}
