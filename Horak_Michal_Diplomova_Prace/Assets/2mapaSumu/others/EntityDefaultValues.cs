public class EntityDefaultValues
{
    //T��da pro nastaven� v�choz�ch hodnot p�i zap�n�n� simulace
    public int TypeEater;//only for animals 1-meateater,2-planteater,3-alleater;

    public int Type;//1-tree,2-plant,3-bush,4-grass;

    public float AgeForMatured;//a� po dosa�en� dosp�losti za�n� ���it semena v okol� jednou za �as

    public float FoodValue;

    public float Regen_hp;

    public float Max_hp;

    public float Energy_regen;//p�i dosa�en� max energy + dosp�lost vyprodukuje jedno sem�nko v okol�

    public float Max_energy;

    public float AgeForDie;

    // public float Range;
    public bool CanReproduce;//if cooldown_left je roven 0

    public float Reproduce_cooldown;

    public int PocatecniPopulace;

  

    public EntityDefaultValues(int typeEater, float mature_age, float foodValue, float regen_hp, float max_hp, float energy_regen, float max_energy, float ageForDie, float range, bool canReproduce, float reproduce_cooldown, int pocatecniPopulace)
    {
        TypeEater = typeEater;
        AgeForMatured = mature_age;
        FoodValue = foodValue;
        Regen_hp = regen_hp;
        Max_hp = max_hp;
        Energy_regen = energy_regen;
        Max_energy = max_energy;
        AgeForDie = ageForDie;
        CanReproduce = canReproduce;
        Reproduce_cooldown = reproduce_cooldown;
        PocatecniPopulace = pocatecniPopulace;
    }
}
