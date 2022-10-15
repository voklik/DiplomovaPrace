using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : Plant
{
    public static PlantDefaultValues PlantDefaultValues;
    public static void Setdefault(PlantDefaultValues _PlantDefaultValues)
    { PlantDefaultValues = _PlantDefaultValues; }
    public void InitKind()
    {
        typeEater = PlantDefaultValues.EntityDefaultValues.TypeEater;
        mature_age = PlantDefaultValues.EntityDefaultValues.AgeForMatured;
        foodValue = PlantDefaultValues.EntityDefaultValues.FoodValue;
        regen_hp = PlantDefaultValues.EntityDefaultValues.Regen_hp;
        max_hp = PlantDefaultValues.EntityDefaultValues.Max_hp;
        energy_regen = PlantDefaultValues.EntityDefaultValues.Energy_regen;
        max_energy = PlantDefaultValues.EntityDefaultValues.Max_energy;
        ageForDie = PlantDefaultValues.EntityDefaultValues.AgeForDie;
        canReproduce = PlantDefaultValues.EntityDefaultValues.CanReproduce;
        reproduce_cooldown = PlantDefaultValues.EntityDefaultValues.Reproduce_cooldown;
       

    }
    public override void Start()
    {
        typeEntity = 2;
        kind = "grass";
        if (PlantDefaultValues != null)
            InitKind();
        base.Start();
        Vector3 pozice = transform.position;
        Destroy(agent);
        transform.position = pozice;
        

    }
}
