using UnityEngine;
using UnityEngine.UI;

public class InformationInfoBox : MonoBehaviour
{   /*
     *Tøída, která slouží pro zobrazení informace v inforbaèním oknì, když se najede na ikonu s informací.
     *Tato tøída existuje, protože ne všechny informace by se vešly do grafického okna, 
     *a když ano, tak by to bylo nepøehledné a ošklivé.
    */
    public static InformationInfoBox InformationInfoBoxStatic;// promìnná je statická, protože existuje pouze jedno informaèní okno ve scénì.
    void Start()
    {
      //  InformationInfoBoxStatic = this;
    }
    void OnEnable()
    {
        Debug.Log("PrintOnEnable: script was enabled");
        InformationInfoBoxStatic = this;
    }
    void OnDisable()
    {
        Debug.Log("PrintOnDisable: script was disabled");
    }
    /// <summary>
    /// Zobrazit text v InfoBoxu
    /// </summary>
    /// <param name="text"></param>
    public static void Show(string text)
    {
        InformationInfoBoxStatic.GetComponentInChildren<Text>().text = text;
    }
    /// <summary>
    /// Schovat text v InfoBoxu
    /// </summary>
    public static void Hide()
    {
        InformationInfoBoxStatic.GetComponentInChildren<Text>().text = "";
    }
}
