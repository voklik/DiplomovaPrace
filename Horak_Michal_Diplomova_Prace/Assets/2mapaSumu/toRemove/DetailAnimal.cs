using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailAnimal 
{   
    int type;//1-meateater,2-planteater,3-alleater;
    float age;
    float mature_age;
    string kind;
    float hp;
    float hunger;
    float thirsty;
    float sleepnes;
    float strenght;
    float energy;
    float ageForDie;
    bool timeToDie;
    string name;
    bool isLive;
    GameObject partner;
    GameObject father, mother;
    List<GameObject> children;

    public DetailAnimal(int type, float age, float mature_age, string kind, float hp, float hunger, float thirsty, float sleepnes, float strenght, float energy, float ageForDie, bool timeToDie, string name, bool isLive, GameObject partner, GameObject father, GameObject mother)
    {
        this.type = type;
        this.age = age;
        this.mature_age = mature_age;
        this.kind = kind;
        this.hp = hp;
        this.hunger = hunger;
        this.thirsty = thirsty;
        this.sleepnes = sleepnes;
        this.strenght = strenght;
        this.energy = energy;
        this.ageForDie = ageForDie;
        this.timeToDie = timeToDie;
        this.name = name;
        this.isLive = isLive;
        this.partner = partner;
        this.father = father;
        this.mother = mother;
    }

    public string getKind()
    {
        return kind;
    }
}
