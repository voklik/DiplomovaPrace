using UnityEngine;
using UnityEngine.UI;

public class WorldGenerateSettings : MonoBehaviour
{
    // T��da, kter� vypln� obsah okna s nastaven�m, ne� se zahajuje simulace.
    public float x = 35, y = 40;
    public static float baseHeight,BaseMaxHeight;
    public static float Multiplier = 10;

    public static float MinHeight = 1, MaxHeinght = 0;

    public static int Width, Depth = 0;
    public static float Seed = 435;

    public Slider SMultiplier, SWidth, SDepth,SSeed;

    public void Awake()
    {
        SMultiplier = GenerateSliderF("Multiplier", "N�sobi� v��ky", "ur�uje v��kov� rozd�l mezi body", 1.6f, 1.6f, 10.0f);
        SWidth = GenerateSliderI("SWidth", "Po�et blok� do ���ky", "Po�et bod� v m��ce sm�rem doprava", 40, 40, 100);
        SDepth = GenerateSliderI("SDepth", "Po�et blok� do hloubky", "Po�et bod� v m��ce sm�rem nahoru", 40, 40, 100);
        SSeed = GenerateSliderF("SSeed", "Sem�nko mapy - doporu�eno 270, anebo 435", "Sem�nko mapy, kter� rozhoduje podobu ter�nu. N�kter� seedy nefunguj� a proto se doporu�uje seed 435,270, proto�e byly vyzkou�ny", 435, 0, 1000);
    }

    private Slider GenerateSliderI(string nazev, string popisek, string infoPopisek, int hodnota, int min, int max)
    {
        GameObject entita = Resources.Load<GameObject>("Slider") as GameObject;
        GameObject novy = Instantiate(entita, new Vector3(0, 0, 0), Quaternion.identity);

        novy.name = "Slider" + nazev;
        novy.transform.Find("Name").GetComponent<Text>().text = popisek;
       // novy.transform.Find("Name").GetComponent<Text>().text = popisek;
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

    private Slider GenerateSliderF(string nazev, string popisek, string infoPopisek, float hodnota, float min, float max)
    {
        GameObject entita = Resources.Load<GameObject>("Slider") as GameObject;
        GameObject novy = Instantiate(entita, new Vector3(0, 0, 0), Quaternion.identity);

        novy.name = "Slider" + nazev;
        novy.transform.Find("Name").GetComponent<Text>().text = popisek;
        //novy.transform.Find("Name").GetComponent<Text>().text = popisek;
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
        // novy.transform.position = new Vector3(0, 0, 0);
        novy.transform.localPosition = new Vector3(x - 100, y + 420, 0);
        //   novy.transform.position = new Vector3(x, y, 0);
        y -= 35;
        return slider;
    }

    public void VariableSet()
    {//Metoda pro tla��tko, tak�e nen� ��dn� reference
        Multiplier = SMultiplier.value;
        Width = (int)SWidth.value;
        Depth = (int)SDepth.value;
    }
}
