using UnityEngine;

public class InformationContainer : MonoBehaviour
{
    public string text;//Text pro InfoBox, kdy se najede myší na herní objekt

    /// <summary>
    /// Metoda pøi najetí myší na tento objekt
    /// </summary>
    public void MouseEnter()
    {
        Debug.Log("info");//TODO SMAZAT TESTOVANI
        InformationInfoBox.Show(text);
    }
    /// <summary>
    /// Metoda pøi vyjetí myši z tohoto objektu
    /// </summary>
    public void MouseExit()
    {
        InformationInfoBox.Hide();
    }
}
