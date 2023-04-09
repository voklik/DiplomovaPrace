using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : Animal
{
    public static AnimalDefaultValues AnimalDefaultValues;
    public static void Setdefault(AnimalDefaultValues _AnimalDefaultValues)
    { AnimalDefaultValues = _AnimalDefaultValues; }
    public void InitKind()
    {
        typeEater = AnimalDefaultValues.EntityDefaultValues.TypeEater;
        mature_age = AnimalDefaultValues.EntityDefaultValues.AgeForMatured;
        foodValue = AnimalDefaultValues.EntityDefaultValues.FoodValue;
        regen_hp = AnimalDefaultValues.EntityDefaultValues.Regen_hp;
        max_hp = AnimalDefaultValues.EntityDefaultValues.Max_hp;
        energy_regen = AnimalDefaultValues.EntityDefaultValues.Energy_regen;
        max_energy = AnimalDefaultValues.EntityDefaultValues.Max_energy;
        ageForDie = AnimalDefaultValues.EntityDefaultValues.AgeForDie;
        canReproduce = AnimalDefaultValues.EntityDefaultValues.CanReproduce;
        reproduce_cooldown = AnimalDefaultValues.EntityDefaultValues.Reproduce_cooldown;
        SetTimePregnancyDefault(AnimalDefaultValues.PregnancyTimeToBornDefault);
        SetTimeHunger(AnimalDefaultValues.Hunger_perSec);
        SetTimeThirsty(AnimalDefaultValues.Thirsty_perSec);
        SetTimeSleep(AnimalDefaultValues.Sleepnes_perSec);
        SetStrenght(AnimalDefaultValues.Strenght);
    }
    public override void Start()
    {
        typeEntity = 1;
        kind = "sheep";
        typeEater = 2;
        if (AnimalDefaultValues != null)
            InitKind();
        base.Start();
    }
    public override void Update()
    {
        base.Update();
    }
}
