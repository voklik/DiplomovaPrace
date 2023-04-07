using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsControl : MonoBehaviour
{
    /*Metoda, kter� slou�� pro vypo�et po�tu fram� za vte�inu
     * 
     */

    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60; //Omezen� na 60FPS za vte�inu
    }
    /// <summary>
    /// Aktualizace po�tu FPS na textu objektu, kter� m� tuto t��du
    /// </summary>
    void Update()
    {
        gameObject.GetComponent<Text>().text = "�as " + Mathf.Round(StatisticSystem.GetTime() * 10.0f) / 10.0f + "\nFPS limit: " + Application.targetFrameRate.ToString() + "\nFPS " + Mathf.Round(1.0f / Time.deltaTime * 10.0f) / 10.0f;
    }
}
