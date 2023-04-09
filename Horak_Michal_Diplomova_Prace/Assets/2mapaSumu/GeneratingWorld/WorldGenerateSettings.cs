using UnityEngine;
using UnityEngine.UI;

public class WorldGenerateSettings : MonoBehaviour
{
    // Tøída, která vyplní obsah okna s nastavením, než se zahajuje simulace.
    public float x = 35, y = 40;
    public static float baseHeight, BaseMaxHeight;
    public static float Multiplier = 10;
    public static float MinHeight = 1, MaxHeinght = 0;
    public static int Width, Depth = 0;
    public static float Seed = 435;
    public Slider SMultiplier, SWidth, SDepth, SSeed;

    public void Awake()
    {
        SMultiplier = GenerateSliderF("Multiplier", "Multiplier", "MultiplierInfo", 1.6f, 1.6f, 10.0f);
        SWidth = GenerateSliderI("SWidth", "SWidth", "SWidthInfo", 40, 40, 100);
        SDepth = GenerateSliderI("SDepth", "SDepth", "SDepthInfo", 40, 40, 100);
        SSeed = GenerateSliderF("Seed", "Seed", "SeedInfo", 435, 0, 1000);
    }

    private Slider GenerateSliderI(string nazev, string popisek, string infoPopisek, int hodnota, int min, int max)
    {
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

    private Slider GenerateSliderF(string nazev, string popisek, string infoPopisek, float hodnota, float min, float max)
    {
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
        infoContainer.text = CaptionsLibrary.GetCaption(infoPopisek
            );
        slider.wholeNumbers = false;
        novy.transform.parent = gameObject.transform;
        novy.transform.localPosition = new Vector3(x - 100, y + 420, 0);
        y -= 35;
        return slider;
    }

    public void VariableSet()
    {//Metoda pro tlaèítko, takže není žádná reference
        Multiplier = SMultiplier.value;
        Width = (int)SWidth.value;
        Depth = (int)SDepth.value;
    }
}
