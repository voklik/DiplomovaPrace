using System.Collections.Generic;
using UnityEngine;

public class MaterialStorage : MonoBehaviour
{
    //Pomocn� t��da, kde se ukl�daj� odkazi na r�zn� objekty, aby se nemusely ur�it� ��sty k�du objevovat na v�ce m�stech
    public static Color Sand, Stone, Earth;

    public Color sand, stone, earth;

    public static GameObject Water, TargetCollider, TextBoxt, BodyCollidera;

    public static List<GameObject> Teren = new List<GameObject>();

    public static ToolltipUI toolltipUI;

    public static GameObject waterPointPreFab;

    public static GameObject EarthPointPreFab;

    [SerializeField] private GameObject Eart;

    public ToolltipUI ToolltipUI;

    public static GenerateObject generator;

    private void Awake()
    {
        //Clear se prov�d�, proto�e v p��pad�, �e se zapne simulace a n�sledn� se vypne a zase zapne, tak aby se nevyskytovali pr�zdn� objekty v seznamu
        Teren.Clear();
        Sand = sand;
        Stone = stone;
        Earth = earth;
        toolltipUI = ToolltipUI;
        waterPointPreFab = Resources.Load<GameObject>("modely/WaterPoint");
        EarthPointPreFab = Resources.Load<GameObject>("modely/EarthPoint");
        TargetCollider = Resources.Load<GameObject>("modely/TargetArea");
        //TextBoxt = Resources.Load<GameObject>("modely/TextField");
        BodyCollidera = Resources.Load<GameObject>("modely/BodyArea");
        Eart = EarthPointPreFab;
        generator = GameObject.Find("Generator").GetComponent<GenerateObject>();
    }
}
