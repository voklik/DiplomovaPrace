using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Animal
{//Pøipravena další tøída pro pøípadné použití.

    public override void Start()
    {
        base.Start();
        kind = "Chicken";
    }
}

