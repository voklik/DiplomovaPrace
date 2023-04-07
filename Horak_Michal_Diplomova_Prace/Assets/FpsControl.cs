using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsControl : MonoBehaviour
{
    /*Metoda, která slouží pro vypoèet poètu framù za vteøinu
     * 
     */

    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60; //Omezení na 60FPS za vteøinu
    }
    /// <summary>
    /// Aktualizace poètu FPS na textu objektu, který má tuto tøídu
    /// </summary>
    void Update()
    {
        gameObject.GetComponent<Text>().text = "Èas " + Mathf.Round(StatisticSystem.GetTime() * 10.0f) / 10.0f + "\nFPS limit: " + Application.targetFrameRate.ToString() + "\nFPS " + Mathf.Round(1.0f / Time.deltaTime * 10.0f) / 10.0f;
    }
}
