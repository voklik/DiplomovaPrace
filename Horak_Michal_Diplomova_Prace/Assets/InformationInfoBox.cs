using UnityEngine;
using UnityEngine.UI;

public class InformationInfoBox : MonoBehaviour
{   /*
     *T��da, kter� slou�� pro zobrazen� informace v informa�n�m okn�, kdy� se najede na ikonu s informac�.
     *Tato t��da existuje, proto�e ne v�echny informace by se ve�ly do grafick�ho okna, 
     *a kdy� ano, tak by to bylo nep�ehledn� a o�kliv�.
    */
    public static InformationInfoBox InformationInfoBoxStatic;// prom�nn� je statick�, proto�e existuje pouze jedno informa�n� okno ve sc�n�.
    void OnEnable()
    {
        InformationInfoBoxStatic = this;
    }
    void OnDisable()
    {
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
