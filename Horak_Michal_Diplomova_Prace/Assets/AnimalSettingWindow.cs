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
        Init.PocatecniPopulace = GenerateSliderI("populace", "Poèáteèní populace", "Kolik jedincù se bude generovat na zaèátku simulace", 2, 0, 20);
        Init.CanReproduce = GenerateSliderI("populaceReprodukce", "Možnost reprodukce", "Zda tento druh se mùže rozmnožovat", 1, 0, 1);
        if (isAnimal == true)
        {
            Init.TypeEater = GenerateSliderI("potrava", "Typ potravy", "1-masožravec, 2-rostlinožravec, 3-všežravec", 3, 1, 3);
        }
        Init.AgeForMatured = GenerateSliderI("matureAge", "Vìk dospívání", "Vìk, kdy jedinec dospívá a mùže zakládat rodiny / u roslin možnost šíøit semínka kolem sebe", 30, 0, 100);
        Init.AgeForDie = GenerateSliderI("dieAge", "Vìk umírání", "Vìk, kdy jedinci zaèíná pasivnì ubývat zdraví a nakonec po èase umírá", 120, 0, 100);
        Init.Max_hp = GenerateSliderI("maxHp", "Maximální zdraví", "Maximální zdraví jedince. Tato hodnota mùže ovlivnit rychlost umírání", 100, 0, 150);
        Init.Regen_hp = GenerateSliderF("regenHp", "Regenerace zdraví za èas", "Množství, které si jedinec doplní za èas. Tato hodnota mùže ovlivnit rychlost umírání", 1, 0, 10);
        Init.Max_energy = GenerateSliderI("maxEnergy", "Maximální energie", "Množství energie rozhoduje o možnosti vzplodit potomka/šíøit semínka. Pro zplození potomka je potøeba maximum energie a vyšší hodnota zvyšuje dobu, než by mohl zplodit jedince", 100, 0, 150);
        Init.Energy_regen = GenerateSliderF("regenEnergy", "Regenerace energie za èas", "Množství, které si jedinec doplní za èas", 1, 0, 10);
        Init.FoodValue = GenerateSliderI("foodValue", "Hodnota potravy pro predatora", "Hodnota potravy pro predátora, který sní jedince tohoto druhu", 50, 0, 200);
        Init.Reproduce_cooldown = GenerateSliderF("reproduceCooldown", "Èas mez porody", "Èas, který urèuje, jak dlouho po porodu/šíøení semínek se bude smìt samice zvíøete stát znova gravitní a u rostlin, kdy bude vypuštìno další semínko okolo", 20, 0, 200);
        //#################AnimalDefaultValues
        if (isAnimal == true)
        {
            Init.Hunger_perSec = GenerateSliderF("timeHlad", "Hlad za èas", "Množství, které jedinec získá za èas. V simulaci se poèítá od 0, kdy není žádná potøeba k maximální hranici, kdy je urgentní potøeba", 1, 0, 10);
            Init.Thirsty_perSec = GenerateSliderF("timeZizen", "Žízeò za èas", "Množství, které jedinec získá za èas. V simulaci se poèítá od 0, kdy není žádná potøebam k maximální hranici, kdy je urgentní potøeba", 1, 0, 10);
            Init.Sleepnes_perSec = GenerateSliderF("timeSpanek", "Potøeba spánku za èas", "Množství, které jedinec získá za èas. V simulaci se poèítá od 0, kdy není žádná potøebam k maximální hranici,  kdy je urgentní potøeba", 1, 0, 10);
            Init.Max_hunger = GenerateSliderF("maxHlad", "Max Hlad", "Maximální hranice hladu > ovlivòuje dobu, kdy jedinec bude uspokojovat tuto potøebu", 100, 0, 150);
            Init.Max_thirsty = GenerateSliderF("maxZizen", "Max Žízeò", "Maximální hranice hladu > ovlivòuje dobu, kdy jedinec bude uspokojovat tuto potøebu", 100, 0, 150);
            Init.Max_sleepnes = GenerateSliderF("maxSpanek", "Max Potøeba spánku", "Maximální hranice hladu > ovlivòuje dobu, kdy jedinec bude uspokojovat tuto potøebu", 100, 0, 150);
            Init.PregnancyTimeToBornDefault = GenerateSliderI("pregnancyTime", "Èas do porodu", "Doba, který urèuje, po jaké dobì, se narodí nový jedinec od zplození", 20, 0, 150);
            Init.Strenght = GenerateSliderI("strenght", "Síla útoku", "Urèuje sílu útoku jedince, kdy útoèí na jiná zvíøata (v obranì, èi pro potravu)", 50, 0, 100);
        }
        else if (isAnimal == false)
        {
            //Pøestože je potrava jen pro zvíøata, tak i Rostliny potøebují mít nìco nastaveno, protože to dìdí z Entity
            Init.TypeEater = GenerateSliderI("potrava", "Typ potravy", "1-masožravec 2-rostlinožravec, 3-všežravec", 2, 1, 3);
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
        novy.transform.Find("Name").GetComponent<Text>().text = popisek;
        novy.transform.Find("Name").GetComponent<Text>().fontSize = 20;
        novy.transform.Find("Name").GetComponent<Text>().supportRichText = true;
        novy.transform.Find("Value").GetComponent<Text>().fontSize = 20;
        Slider slider = novy.GetComponent<Slider>();
        slider.minValue = min;
        slider.maxValue = max;
        slider.value = hodnota;
        InformationContainer infoContainer = novy.transform.Find("InfoBox").GetComponent<InformationContainer>();
        infoContainer.text = infoPopisek;
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
        novy.transform.Find("Name").GetComponent<Text>().text = popisek;
        novy.transform.Find("Name").GetComponent<Text>().fontSize = 20;
        novy.transform.Find("Name").GetComponent<Text>().supportRichText = true;
        novy.transform.Find("Value").GetComponent<Text>().fontSize = 20;
        Slider slider = novy.GetComponent<Slider>();
        slider.minValue = min;
        slider.maxValue = max;
        slider.value = hodnota;
        InformationContainer infoContainer = novy.transform.Find("InfoBox").GetComponent<InformationContainer>();
        infoContainer.text = infoPopisek;
        slider.wholeNumbers = false;
        novy.transform.parent = gameObject.transform;
        novy.transform.localPosition = new Vector3(x - 100, y + 420, 0);
        y -= 35;
        return slider;
    }
}
