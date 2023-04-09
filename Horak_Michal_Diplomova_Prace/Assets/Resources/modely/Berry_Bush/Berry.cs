using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berry : Plant
{
    //NEVYU�ITO
    //T��da reprezentuje druh jedl� rostliny pro zv��ata
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
