using UnityEngine;
using UnityEngine.UI;

public class InitEntitSet : MonoBehaviour
{
    /*
     * T��da, kter� slou�� pro nastaven� vlastnost� zv��at a rostlin.
     * T��d� se p�i�azuj� slidery z rozhran�, kde u�ivatel vyb�r� mo�nosti. Po vybr�n� n�sledn� ulo�� informace k ur�it�mu druhu
     */

    public Entita Entita;

    //Typem je slider, proto�e v prvotn� f�zi se p�i�ad� objekt slider ke skriptu a n�sledn� se v�echny vlastnosti nastav� dan�mu druhu
    public Slider TypeEater;//(Jen zv��ata) 1-maso�ravec, 2-vegetari�n,3-v�e�ravec > ��seln� hodnoty, proto�e slider nem� list

    public Slider Type;//(Jen rostliny)1-Strom,2-Rostlina,3-Ke�,4-Tr�va; P�vodn� se pl�novalo v�ce druh� rostlin, ne� je tr�va> ��seln� hodnoty, proto�e slider nem� list

    public Slider AgeForMatured;//Po�et ve vte�in�ch, kdy entita dosp�je. Po dosa�en� hranice dosp�losti, tak zv��e bude hledat partnera a rostlina bude ���it semena ve sv�m okol�

    public Slider FoodValue;//Ten, kter� se bude krmit na t�to entit�, bude z�sk�vat v pr�b�hu krmen� tuto hodnotu.

    public Slider Regen_hp;//Rychlost, jak�m entita bude obnovovat sv� body �ivota

    public Slider Max_hp;//Maxim�ln� po�et �ivoat

    public Slider Energy_regen;//Rychlost obnovov�n� bod� energie

    public Slider Max_energy;//Maxim�ln� po�et energie

    public Slider AgeForDie;//V�k, kdy entita za�ne pr�b�n� ztr�ce sv� body �ivota.

    public Slider CanReproduce;//M��e entita se rozmno�ovat po tom, co dos�hne dosp�losti

    public Slider Reproduce_cooldown;// Po�et vte�in, kdy nem��e entita se rozmno�ovat po posledn�m porodu/���en� semen

    public Slider PocatecniPopulace;//Po�et jedinc� tohoto druhu entity.
    //TODO SMAZAT
    //####Animal 
    // public float PartnerMaxRange = 20.0f;
    // public float TargetRange = 2.0f;
    public Slider PregnancyTimeToBornDefault;//Doba, jak dlouho samice zv��at budou t�hotn�, ne� porod�.

    public Slider Max_hunger;//Maxim�ln� hodnota hladu

    public Slider Hunger_perSec;//Kolik zv��e z�sk�v� bod� hladu za vte�inu

    public Slider Max_thirsty;//Maxim�ln� hodnota ��zn� 

    public Slider Thirsty_perSec;//Kolik zv��e z�sk�v� bod� ��zn� za vte�inu

    public Slider Max_sleepnes;//Maxim�ln� hodnota sp�nk� 

    public Slider Sleepnes_perSec;//Kolik zv��e z�sk�v� bod� sp�nk� za vte�inu

    public Slider Strenght;//Kolik zv��e vezme �ivot� jin� entit�, kdy� �to��

    /// <summary>
    /// Ulo�en� informac� k vybran� entit�
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
    /// Vytvo�en� informa�n�ho souhrnu pro zv��e
    /// </summary>
    /// <param name="en"></param>
    /// <returns></returns>
    private AnimalDefaultValues CreateAnimalDefault(EntityDefaultValues en)
    {
        AnimalDefaultValues novy = new AnimalDefaultValues(CreateEntityDefault(), 0, 0, PregnancyTimeToBornDefault.value, Max_hunger.value, Hunger_perSec.value, Max_thirsty.value, Thirsty_perSec.value, Max_sleepnes.value, Sleepnes_perSec.value, Strenght.value);
        return novy;
    }
    /// <summary>
    /// Vytvo�en� informa�n�ho souhrnu, kter� je spole�n� pro zv��ata i rostliny
    /// </summary>
    /// <returns></returns>
    private EntityDefaultValues CreateEntityDefault()
    {
        EntityDefaultValues novy = new EntityDefaultValues((int)TypeEater.value, AgeForMatured.value, FoodValue.value, Regen_hp.value, Max_hp.value, Energy_regen.value, Max_energy.value, AgeForDie.value, 0, (CanReproduce.value == 1) ? true : false, Reproduce_cooldown.value, (int)PocatecniPopulace.value);
        return novy;
    }


    /// <summary>
    /// Vytvo�en� informa�n�ho souhrnu pro rostlinu
    /// </summary>
    /// <param name="en"></param>
    /// <returns></returns>
    private PlantDefaultValues CreatePlantDefault()
    {
        return new PlantDefaultValues(CreateEntityDefault());
    }
}
