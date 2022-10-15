using System.Collections.Generic;
using UnityEngine;

public class MaterialStorage : MonoBehaviour
{
    //Pomocná tøída, kde se ukládají odkazi na rùzné objekty, aby se nemusely urèité èásty kódu objevovat na více místech
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
        //Clear se provádí, protože v pøípadì, že se zapne simulace a následnì se vypne a zase zapne, tak aby se nevyskytovali prázdné objekty v seznamu
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
