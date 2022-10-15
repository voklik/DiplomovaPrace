using UnityEngine;

public class CloseWindowScript : MonoBehaviour
{
    /*Metoda pro zav�en� okna pomoc� tla��tka v rozhran�.
    Tato t��da s odkazem na okno se p�i�ad� k tla��tku, proto nen� ��dn� refence.
    */
    [SerializeField] GameObject Window;

    public void Close()
    {
        if (Window != null)
        {
            if (Window.activeInHierarchy)
            { Window.SetActive(false); }
        }
    }
}
