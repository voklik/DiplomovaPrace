using UnityEngine;

public class CloseWindowScript : MonoBehaviour
{
    /*Metoda pro zavøení okna pomocí tlaèítka v rozhraní.
    Tato tøída s odkazem na okno se pøiøadí k tlaèítku, proto není žádná refence.
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
