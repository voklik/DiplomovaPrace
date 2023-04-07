using UnityEngine;

public class InformationContainer : MonoBehaviour
{
    public string text;//Text pro InfoBox, kdy se najede my�� na hern� objekt

    /// <summary>
    /// Metoda p�i najet� my�� na tento objekt
    /// </summary>
    public void MouseEnter()
    {
        Debug.Log("info");//TODO SMAZAT TESTOVANI
        InformationInfoBox.Show(text);
    }
    /// <summary>
    /// Metoda p�i vyjet� my�i z tohoto objektu
    /// </summary>
    public void MouseExit()
    {
        InformationInfoBox.Hide();
    }
}
