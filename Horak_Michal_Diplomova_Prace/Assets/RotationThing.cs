using UnityEngine;

public class RotationThing : MonoBehaviour
{
    // T��da, kter� se p�i�ad� k objektu a ten bude rotovat.
    //Vyu��v� se to nap��klad pro rotov�n� srd��ka, kdy� se oplodn� samice
    void Start()
    {
        Destroy(gameObject, 5);
    }    
    void Update()
    {
        transform.Rotate(0, -1f, 0);
    }
}
