using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berry : Plant
{
    //Tøída reprezentuje druh jedlé rostliny pro zvíøata
    [SerializeField] private BerrySpot berrySpot;

    public void SetBerrySpot(BerrySpot b)
    {
        berrySpot = b;
    }

    new
        void OnDestroy()
    {
        berrySpot.BerryIsDead();
        ClearLists();
    }
}
