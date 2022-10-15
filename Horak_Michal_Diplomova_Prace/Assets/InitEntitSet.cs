using UnityEngine;
using UnityEngine.UI;

public class InitEntitSet : MonoBehaviour
{
    /*
     * Tøída, která slouží pro nastavení vlastností zvíøat a rostlin.
     * Tøídì se pøiøazují slidery z rozhraní, kde uživatel vybýrá možnosti. Po vybrání následnì uloží informace k urèitému druhu
     */

    public Entita Entita;

    //Typem je slider, protože v prvotní fázi se pøiøadí objekt slider ke skriptu a následnì se všechny vlastnosti nastaví danému druhu
    public Slider TypeEater;//(Jen zvíøata) 1-masožravec, 2-vegetarián,3-všežravec > Èíselné hodnoty, protože slider nemá list

    public Slider Type;//(Jen rostliny)1-Strom,2-Rostlina,3-Keø,4-Tráva; Pùvodnì se plánovalo více druhù rostlin, než je tráva> Èíselné hodnoty, protože slider nemá list

    public Slider AgeForMatured;//Poèet ve vteøinách, kdy entita dospìje. Po dosažení hranice dospìlosti, tak zvíøe bude hledat partnera a rostlina bude šíøit semena ve svém okolí

    public Slider FoodValue;//Ten, který se bude krmit na této entitì, bude získávat v prùbìhu krmení tuto hodnotu.

    public Slider Regen_hp;//Rychlost, jakým entita bude obnovovat své body života

    public Slider Max_hp;//Maximální poèet živoat

    public Slider Energy_regen;//Rychlost obnovování bodù energie

    public Slider Max_energy;//Maximální poèet energie

    public Slider AgeForDie;//Vìk, kdy entita zaène prùbìžnì ztráce své body života.

    public Slider CanReproduce;//Mùže entita se rozmnožovat po tom, co dosáhne dospìlosti

    public Slider Reproduce_cooldown;// Poèet vteøin, kdy nemùže entita se rozmnožovat po posledním porodu/šíøení semen

    public Slider PocatecniPopulace;//Poèet jedincù tohoto druhu entity.
    //TODO SMAZAT
    //####Animal 
    // public float PartnerMaxRange = 20.0f;
    // public float TargetRange = 2.0f;
    public Slider PregnancyTimeToBornDefault;//Doba, jak dlouho samice zvíøat budou tìhotné, než porodí.

    public Slider Max_hunger;//Maximální hodnota hladu

    public Slider Hunger_perSec;//Kolik zvíøe získává bodù hladu za vteøinu

    public Slider Max_thirsty;//Maximální hodnota žíznì 

    public Slider Thirsty_perSec;//Kolik zvíøe získává bodù žíznì za vteøinu

    public Slider Max_sleepnes;//Maximální hodnota spánkù 

    public Slider Sleepnes_perSec;//Kolik zvíøe získává bodù spánkù za vteøinu

    public Slider Strenght;//Kolik zvíøe vezme životù jiné entitì, když útoèí

    /// <summary>
    /// Uložení informací k vybrané entitì
    /// </summary>
    public void SaveValue()
    {
        switch (Entita)
        {
            case Entita.Vlk:
                Wolf.setdefault(CreateAnimalDefault(CreateEntityDefault()));
                break;
            case Entita.Ovce:
                Sheep.Setdefault(CreateAnimalDefault(CreateEntityDefault()));
                break;
            case Entita.Trava:
                Grass.Setdefault(CreatePlantDefault());
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// Vytvoøení informaèního souhrnu pro zvíøe
    /// </summary>
    /// <param name="en"></param>
    /// <returns></returns>
    private AnimalDefaultValues CreateAnimalDefault(EntityDefaultValues en)
    {
        AnimalDefaultValues novy = new AnimalDefaultValues(CreateEntityDefault(), 0, 0, PregnancyTimeToBornDefault.value, Max_hunger.value, Hunger_perSec.value, Max_thirsty.value, Thirsty_perSec.value, Max_sleepnes.value, Sleepnes_perSec.value, Strenght.value);
        return novy;
    }
    /// <summary>
    /// Vytvoøení informaèního souhrnu, který je spoleèný pro zvíøata i rostliny
    /// </summary>
    /// <returns></returns>
    private EntityDefaultValues CreateEntityDefault()
    {
        EntityDefaultValues novy = new EntityDefaultValues((int)TypeEater.value, AgeForMatured.value, FoodValue.value, Regen_hp.value, Max_hp.value, Energy_regen.value, Max_energy.value, AgeForDie.value, 0, (CanReproduce.value == 1) ? true : false, Reproduce_cooldown.value, (int)PocatecniPopulace.value);
        return novy;
    }


    /// <summary>
    /// Vytvoøení informaèního souhrnu pro rostlinu
    /// </summary>
    /// <param name="en"></param>
    /// <returns></returns>
    private PlantDefaultValues CreatePlantDefault()
    {
        return new PlantDefaultValues(CreateEntityDefault());
    }
}
