using UnityEngine;
using UnityEngine.UI;

public class AnimalSettingWindow : MonoBehaviour
{
    //Tøída, která slouží pro vytvoøení obsahu kontejneru pøi nastavování simulace.
    //Tento obsah je takto generován, protože ruènì vkládat obsah do okna by zpùsobilo,
    //že by nebyl pøesný poèet pixelù mezi øádky a další problémy.
    public float x = 35, y = 40;//Nutnost, aby text zaèínal na zaèátku okna. Dùvodem je prvotní odsazení.

    public bool isAnimal = true;//Upravuje se zvíøe ?

    public InitEntitSet Init;

    /// <summary>
    /// Vygenerování sliderù pro pøíslušný druh entity
    /// </summary>
    void Start()
    {
        //#################EntityDefaultValues
        Init.PocatecniPopulace = GenerateSliderI("populace", "populace", "populaceInfo", 2, 0, 20);
        Init.CanReproduce = GenerateSliderI("populaceReprodukce", "populaceReprodukce", "populaceReprodukceInfo", 1, 0, 1);
        if (isAnimal == true)
        {
            Init.TypeEater = GenerateSliderI("potrava", "potrava", "potravaInfo", 3, 1, 3);
        }
        Init.AgeForMatured = GenerateSliderI("matureAge", "matureAge", "matureAgeInfo", 30, 0, 100);
        Init.AgeForDie = GenerateSliderI("dieAge", "dieAge", "dieAgeInfo", 120, 0, 100);
        Init.Max_hp = GenerateSliderI("maxHp", "maxHp", "maxHpInfo", 100, 0, 150);
        Init.Regen_hp = GenerateSliderF("regenHp", "regenHp", "regenHpInfo", 1, 0, 10);
        Init.Max_energy = GenerateSliderI("maxEnergy", "maxEnergy", "maxEnergyInfo", 100, 0, 150);
        Init.Energy_regen = GenerateSliderF("regenEnergy", "regenEnergy", "regenEnergyInfo", 1, 0, 10);
        Init.FoodValue = GenerateSliderI("foodValue", "foodValue", "foodValueInfo", 50, 0, 200);
        Init.Reproduce_cooldown = GenerateSliderF("reproduceCooldown", "reproduceCooldown", "reproduceCooldownInfo", 20, 0, 200);
        //#################AnimalDefaultValues
        if (isAnimal == true)
        {
            Init.Hunger_perSec = GenerateSliderF("timeHlad", "timeHlad", "timeHladInfo", 1, 0, 10);
            Init.Thirsty_perSec = GenerateSliderF("timeZizen", "timeZizen", "timeZizenInfo", 1, 0, 10);
            Init.Sleepnes_perSec = GenerateSliderF("timeSpanek", "timeSpanek", "timeSpanekInfo", 1, 0, 10);
            Init.Max_hunger = GenerateSliderF("maxHlad", "maxHlad", "maxHladInfo", 100, 0, 150);
            Init.Max_thirsty = GenerateSliderF("maxZizen", "maxZizen", "maxZizenInfo", 100, 0, 150);
            Init.Max_sleepnes = GenerateSliderF("maxSpanek", "maxSpanek", "maxSpanekInfo", 100, 0, 150);
            Init.PregnancyTimeToBornDefault = GenerateSliderI("pregnancyTime", "pregnancyTime", "pregnancyTimeInfo", 20, 0, 150);
            Init.Strenght = GenerateSliderI("strenght", "strenght", "strenghtInfo", 50, 0, 100);
        }
        else if (isAnimal == false)
        {
            //Pøestože je potrava jen pro zvíøata, tak i Rostliny potøebují mít nìco nastaveno, protože to dìdí z Entity
            Init.TypeEater = GenerateSliderI("potrava", "potrava", "potravaInfo", 2, 1, 3);
            Init.TypeEater.enabled = false;
        }
    }
    //Vytvoøení slideru, který má integer hodnotu
    private Slider GenerateSliderI(string nazev, string popisek, string infoPopisek, int hodnota, int min, int max)
    {
        //Generování Integer Slider
        GameObject entita = Resources.Load<GameObject>("Slider") as GameObject;
        GameObject novy = Instantiate(entita, new Vector3(0, 0, 0), Quaternion.identity);

        novy.name = "Slider" + nazev;
        novy.transform.Find("Name").GetComponent<Text>().text = CaptionsLibrary.GetCaption(popisek);
        novy.transform.Find("Name").GetComponent<Text>().fontSize = 20;
        novy.transform.Find("Name").GetComponent<Text>().supportRichText = true;
        novy.transform.Find("Value").GetComponent<Text>().fontSize = 20;
        Slider slider = novy.GetComponent<Slider>();
        slider.minValue = min;
        slider.maxValue = max;
        slider.value = hodnota;
        InformationContainer infoContainer = novy.transform.Find("InfoBox").GetComponent<InformationContainer>();
        infoContainer.text = CaptionsLibrary.GetCaption(infoPopisek);
        slider.wholeNumbers = true;
        novy.transform.parent = gameObject.transform;
        novy.transform.localPosition = new Vector3(x - 100, y + 420, 0);        
        y -= 35;
        return slider;
    }
    //Vytvoøení slideru, který má float hodnotu
    private Slider GenerateSliderF(string nazev, string popisek, string infoPopisek, float hodnota, float min, float max)
    {
        //Generování Float Slider
        GameObject entita = Resources.Load<GameObject>("Slider") as GameObject;
        GameObject novy = Instantiate(entita, new Vector3(0, 0, 0), Quaternion.identity);
        novy.name = "Slider" + nazev;
        novy.transform.Find("Name").GetComponent<Text>().text = CaptionsLibrary.GetCaption(popisek);
        novy.transform.Find("Name").GetComponent<Text>().fontSize = 20;
        novy.transform.Find("Name").GetComponent<Text>().supportRichText = true;
        novy.transform.Find("Value").GetComponent<Text>().fontSize = 20;
        Slider slider = novy.GetComponent<Slider>();
        slider.minValue = min;
        slider.maxValue = max;
        slider.value = hodnota;
        InformationContainer infoContainer = novy.transform.Find("InfoBox").GetComponent<InformationContainer>();
        infoContainer.text = CaptionsLibrary.GetCaption(infoPopisek);
        slider.wholeNumbers = false;
        novy.transform.parent = gameObject.transform;
        novy.transform.localPosition = new Vector3(x - 100, y + 420, 0);
        y -= 35;
        return slider;
    }
}
