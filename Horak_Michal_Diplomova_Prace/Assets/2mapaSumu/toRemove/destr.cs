using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destr : MonoBehaviour
{
   [SerializeField] DetailAnimal detail;
    // Start is called before the first frame update
    void Awake()
    {
        detail = new DetailAnimal(2, 0, 300, "wolf", 100, 0, 0, 0, 5, 100, 900, false, gameObject.name, true, null, null, null);

     //   Object.Destroy(gameObject,15);

    }

    public DetailAnimal GetDetail()
    {
        return detail;
    }
       
    // Update is called once per frame
    void Update()
    {
        
    }
}
