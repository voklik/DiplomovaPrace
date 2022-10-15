using UnityEngine;
using UnityEngine.UI;

public class AnimalSettingWindow : MonoBehaviour
{
    //T��da, kter� slou�� pro vytvo�en� obsahu kontejneru p�i nastavov�n� simulace.
    //Tento obsah je takto generov�n, proto�e ru�n� vkl�dat obsah do okna by zp�sobilo,
    //�e by nebyl p�esn� po�et pixel� mezi ��dky a dal�� probl�my.
    public float x = 35, y = 40;//Nutnost, aby text za��nal na za��tku okna. D�vodem je prvotn� odsazen�.

    public bool isAnimal = true;//Upravuje se zv��e ?

    public InitEntitSet Init;

    /// <summary>
    /// Vygenerov�n� slider� pro p��slu�n� druh entity
    /// </summary>
    void Start()
    {
        //#################EntityDefaultValues
        Init.PocatecniPopulace = GenerateSliderI("populace", "Po��te�n� populace", "Kolik jedinc� se bude generovat na za��tku simulace", 2, 0, 20);
        Init.CanReproduce = GenerateSliderI("populaceReprodukce", "Mo�nost reprodukce", "Zda tento druh se m��e rozmno�ovat", 1, 0, 1);
        if (isAnimal == true)
        {
            Init.TypeEater = GenerateSliderI("potrava", "Typ potravy", "1-maso�ravec, 2-rostlino�ravec, 3-v�e�ravec", 3, 1, 3);
        }
        Init.AgeForMatured = GenerateSliderI("matureAge", "V�k dosp�v�n�", "V�k, kdy jedinec dosp�v� a m��e zakl�dat rodiny / u roslin mo�nost ���it sem�nka kolem sebe", 30, 0, 100);
        Init.AgeForDie = GenerateSliderI("dieAge", "V�k um�r�n�", "V�k, kdy jedinci za��n� pasivn� ub�vat zdrav� a nakonec po �ase um�r�", 120, 0, 100);
        Init.Max_hp = GenerateSliderI("maxHp", "Maxim�ln� zdrav�", "Maxim�ln� zdrav� jedince. Tato hodnota m��e ovlivnit rychlost um�r�n�", 100, 0, 150);
        Init.Regen_hp = GenerateSliderF("regenHp", "Regenerace zdrav� za �as", "Mno�stv�, kter� si jedinec dopln� za �as. Tato hodnota m��e ovlivnit rychlost um�r�n�", 1, 0, 10);
        Init.Max_energy = GenerateSliderI("maxEnergy", "Maxim�ln� energie", "Mno�stv� energie rozhoduje o mo�nosti vzplodit potomka/���it sem�nka. Pro zplozen� potomka je pot�eba maximum energie a vy��� hodnota zvy�uje dobu, ne� by mohl zplodit jedince", 100, 0, 150);
        Init.Energy_regen = GenerateSliderF("regenEnergy", "Regenerace energie za �as", "Mno�stv�, kter� si jedinec dopln� za �as", 1, 0, 10);
        Init.FoodValue = GenerateSliderI("foodValue", "Hodnota potravy pro predatora", "Hodnota potravy pro pred�tora, kter� sn� jedince tohoto druhu", 50, 0, 200);
        Init.Reproduce_cooldown = GenerateSliderF("reproduceCooldown", "�as mez porody", "�as, kter� ur�uje, jak dlouho po porodu/���en� sem�nek se bude sm�t samice zv��ete st�t znova gravitn� a u rostlin, kdy bude vypu�t�no dal�� sem�nko okolo", 20, 0, 200);
        //#################AnimalDefaultValues
        if (isAnimal == true)
        {
            Init.Hunger_perSec = GenerateSliderF("timeHlad", "Hlad za �as", "Mno�stv�, kter� jedinec z�sk� za �as. V simulaci se po��t� od 0, kdy nen� ��dn� pot�eba k maxim�ln� hranici, kdy je urgentn� pot�eba", 1, 0, 10);
            Init.Thirsty_perSec = GenerateSliderF("timeZizen", "��ze� za �as", "Mno�stv�, kter� jedinec z�sk� za �as. V simulaci se po��t� od 0, kdy nen� ��dn� pot�ebam k maxim�ln� hranici, kdy je urgentn� pot�eba", 1, 0, 10);
            Init.Sleepnes_perSec = GenerateSliderF("timeSpanek", "Pot�eba sp�nku za �as", "Mno�stv�, kter� jedinec z�sk� za �as. V simulaci se po��t� od 0, kdy nen� ��dn� pot�ebam k maxim�ln� hranici,  kdy je urgentn� pot�eba", 1, 0, 10);
            Init.Max_hunger = GenerateSliderF("maxHlad", "Max Hlad", "Maxim�ln� hranice hladu > ovliv�uje dobu, kdy jedinec bude uspokojovat tuto pot�ebu", 100, 0, 150);
            Init.Max_thirsty = GenerateSliderF("maxZizen", "Max ��ze�", "Maxim�ln� hranice hladu > ovliv�uje dobu, kdy jedinec bude uspokojovat tuto pot�ebu", 100, 0, 150);
            Init.Max_sleepnes = GenerateSliderF("maxSpanek", "Max Pot�eba sp�nku", "Maxim�ln� hranice hladu > ovliv�uje dobu, kdy jedinec bude uspokojovat tuto pot�ebu", 100, 0, 150);
            Init.PregnancyTimeToBornDefault = GenerateSliderI("pregnancyTime", "�as do porodu", "Doba, kter� ur�uje, po jak� dob�, se narod� nov� jedinec od zplozen�", 20, 0, 150);
            Init.Strenght = GenerateSliderI("strenght", "S�la �toku", "Ur�uje s�lu �toku jedince, kdy �to�� na jin� zv��ata (v obran�, �i pro potravu)", 50, 0, 100);
        }
        else if (isAnimal == false)
        {
            //P�esto�e je potrava jen pro zv��ata, tak i Rostliny pot�ebuj� m�t n�co nastaveno, proto�e to d�d� z Entity
            Init.TypeEater = GenerateSliderI("potrava", "Typ potravy", "1-maso�ravec 2-rostlino�ravec, 3-v�e�ravec", 2, 1, 3);
            Init.TypeEater.enabled = false;
        }
    }
    //Vytvo�en� slideru, kter� m� integer hodnotu
    private Slider GenerateSliderI(string nazev, string popisek, string infoPopisek, int hodnota, int min, int max)
    {
        //Generov�n� Integer Slider
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
    //Vytvo�en� slideru, kter� m� float hodnotu
    private Slider GenerateSliderF(string nazev, string popisek, string infoPopisek, float hodnota, float min, float max)
    {
        //Generov�n� Float Slider
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
