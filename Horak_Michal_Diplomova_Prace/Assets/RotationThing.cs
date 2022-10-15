using UnityEngine;

public class RotationThing : MonoBehaviour
{
    // Tøída, která se pøiøadí k objektu a ten bude rotovat.
    //Využívá se to napøíklad pro rotování srdíèka, když se oplodní samice
    void Start()
    {
        Destroy(gameObject, 5);
    }    
    void Update()
    {
        transform.Rotate(0, -1f, 0);
    }
}
