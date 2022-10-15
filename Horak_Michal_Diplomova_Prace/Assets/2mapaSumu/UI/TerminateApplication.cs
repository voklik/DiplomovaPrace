using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminateApplication : MonoBehaviour
{
    //P�i�azuje se k tla��tku na hlavn�m menu, aby se mohla ukon�it cel� aplikace
    public void ExterminateApplication()
    {
        // Rozhoduje se, zda se vypne hra, �i v enginu se zru�� prob�haj�c� testov�n�
#if UNITY_EDITOR
      
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
