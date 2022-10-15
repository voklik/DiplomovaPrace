public class AnimalDefaultValues
{
    //Tøída pro nastavení výchozích hodnot pøi zapínání simulace
    public EntityDefaultValues EntityDefaultValues;

    public float PregnancyTimeToBornDefault = 120.0f;

    public float Max_hunger = 100;

    public float Hunger_perSec = 0.3f;

    public float Max_thirsty = 100;

    public float Thirsty_perSec = 0.3f;

    public float Max_sleepnes = 100;

    public float Sleepnes_perSec = 0.3f;

    public float Strenght = 20;

    public AnimalDefaultValues(EntityDefaultValues entityDefaultValues, float partnerMaxRange, float targetRange, float pregnancyTimeToBornDefault, float max_hunger, float hunger_perSec, float max_thirsty, float thirsty_perSec, float max_sleepnes, float sleepnes_perSec, float strenght)
    {
        EntityDefaultValues = entityDefaultValues;

        PregnancyTimeToBornDefault = pregnancyTimeToBornDefault;

        Max_hunger = max_hunger;
        Hunger_perSec = hunger_perSec;
        Max_thirsty = max_thirsty;
        Thirsty_perSec = thirsty_perSec;
        Max_sleepnes = max_sleepnes;
        Sleepnes_perSec = sleepnes_perSec;
        Strenght = strenght;
    }
}
