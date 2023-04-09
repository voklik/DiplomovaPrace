using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class Map : MonoBehaviour
{
    [SerializeField] public NavMeshSurface nav;
    public GameObject navmesh;
    public RawImage img;
    [Header("Dimensions")]
    public int width;
    public int height;
    public float scale;
    [Range(1f, 999f)]
    public float randomSeed;//270,435
    public Vector2 offset;
    public GameObject preFab;
    [Header("Height Map")]
    public float[,] heightMap;
    public float baseheight = 5, maxheight = 10;
    public float height_y = 5;
    [SerializeField] private float min = 1, max = 0;
    [Header("Water")]
    public GameObject waterPreFab;
    [Range(0.8f, 3)]
    public float waterHeight = 1.6f;
    public static GameObject water;
    [Header("Population")]
    [Range(0, 10)]
    public int wolfPopulation;
    [Range(0, 10)]
    public int sheepPopulation;
    [Range(0, 10)]
    public int grassPopulation;
    [Header("Camera")]
    public new GameObject camera;

    public void Start()
    {
        if (WorldGenerateSettings.Width == 0)
            WorldGenerateSettings.Width = 40;
        if (WorldGenerateSettings.Depth == 0)
            WorldGenerateSettings.Depth = 40;
        width = WorldGenerateSettings.Width;
        min = int.MaxValue;
        max = int.MinValue;
        height = WorldGenerateSettings.Depth;
        WorldGenerateSettings.Multiplier = height_y;
        WorldGenerateSettings.BaseMaxHeight = maxheight * height_y;
        WorldGenerateSettings.baseHeight = WorldGenerateSettings.BaseMaxHeight * 0.2f;
        if (Wolf.AnimalDefaultValues.EntityDefaultValues.PocatecniPopulace != 0)
        {
            wolfPopulation = Wolf.AnimalDefaultValues.EntityDefaultValues.PocatecniPopulace;
        }
        if (Sheep.AnimalDefaultValues.EntityDefaultValues.PocatecniPopulace != 0)
        {
            sheepPopulation = Sheep.AnimalDefaultValues.EntityDefaultValues.PocatecniPopulace;
        }
        if (Grass.PlantDefaultValues.EntityDefaultValues.PocatecniPopulace != 0)
        {
            grassPopulation = Grass.PlantDefaultValues.EntityDefaultValues.PocatecniPopulace;
        }
        GenerateNoiseMap();

        Renderer renderer = GetComponent<Renderer>();
        GenerateTerrain(width, height, height_y);
        GenerateTerrainUnderground(width, height, height_y);
        foreach (GameObject item in MaterialStorage.Teren)
        {
            item.GetComponent<Teren>().SetInit(waterPreFab);
        }
        WorldGenerateSettings.MinHeight = min;
        WorldGenerateSettings.MaxHeinght = max;
        GenerateWater();
        GameObject navmes = Instantiate(navmesh, new Vector3(0, 0, 0), Quaternion.identity);
        foreach (GameObject item in MaterialStorage.Teren)
        {
            item.GetComponent<Teren>().SetBanare(min * (float)height_y * waterHeight);
        }
        nav.buildHeightMesh = true;
        nav.BuildNavMesh();
        camera.AddComponent<CameraControl>();
        gameObject.GetComponent<GenerateObject>().GenerateEntityPopulation("wolf", wolfPopulation, Vector3.zero);
        gameObject.GetComponent<GenerateObject>().GenerateEntityPopulation("grass", grassPopulation, Vector3.zero);
        gameObject.GetComponent<GenerateObject>().GenerateEntityPopulation("sheep", sheepPopulation, Vector3.zero);

    }
    private void GenerateWater()
    {
        water = Instantiate(waterPreFab, new Vector3(width, (WorldGenerateSettings.BaseMaxHeight * 0.6f), height), Quaternion.identity);
        water.name = "Water";
        water.transform.localScale = new Vector3(width / 4, WorldGenerateSettings.BaseMaxHeight * 0.6f, height / 4);
        MaterialStorage.Water = water;
    }

    void GenerateNoiseMap()
    {
        if (WorldGenerateSettings.Seed != null)
        { randomSeed = WorldGenerateSettings.Seed; }
        heightMap = GenerateNois.Generate(width, height, scale, offset, baseheight, maxheight, randomSeed);
        Color[] pixels = new Color[width * height];
        int i = 0;
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                pixels[i] = Color.Lerp(Color.black, Color.white, heightMap[x, y]);
                i++;
            }
        }
        Texture2D tex = new Texture2D(width, height);
        tex.SetPixels(pixels);
        tex.filterMode = FilterMode.Point;
        tex.Apply();
        img.texture = tex;

    }

    private Vector3[] vertices;
    public void GenerateTerrain(int width, int height, float multiplier)
    {
        int xSize = width;
        int zSize = height;
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];
        for (int i = 0, y = 0; y <= zSize; y++)
        {
            for (int x = 0; x <= xSize; x++, i++)
            {
                vertices[i] = new Vector3(x, y);
            }
        }
        float y1 = 0;
        float y2 = 0;
        float y3 = 0;
        float y4 = 0;
        GameObject g, s;

        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {   //vlevo
                //1vlevo naho�e, 2vpravo  naho�e, 3 vlevo dole, 4 vpravo dole ;
                int x1 = x + 0;
                int z1 = z + 0;
                int x2 = x;
                int z2 = z + 2;
                int x3 = x + 2;
                int z3 = z;
                int x4 = x + 2;
                int z4 = z + 2;
                try
                {

                    if (z == 0)
                    {
                        continue;
                    }
                    else if (z == height - 1)
                    {
                        continue;
                    }
                    else
                    {
                        //vlevo
                        //1vlevo naho�e, 2vpravo  naho�e, 3 vlevo dole, 4 vpravo dole ;
                        x1 = x + 0;
                        x2 = x;
                        z2 = z + 1;
                        x3 = x + 1;
                        z3 = z;
                        x4 = x + 1;
                        z4 = z + 1;
                        y1 = GenerateNois.map[x1, z1 - 1];
                        y2 = GenerateNois.map[x2, z2 - 1];
                        y3 = GenerateNois.map[x3, z3 - 1];
                        y4 = GenerateNois.map[x4, z4 - 1];
                        if (y1 > max)
                            max = y1;
                        if (y1 < min)
                            min = y1;
                        y1 *= multiplier;
                        y2 *= multiplier;
                        y3 *= multiplier;
                        y4 *= multiplier;
                    }

                    s = Instantiate(preFab, new Vector3(x + 0.5f, 0, z), Quaternion.identity);
                    s.GetComponent<TriangleDraw>().DrawPlane(x1, y1, z1, x2, y2, z2, x3, y3, z3, x4, y4, z4);
                    s.name = "x:" + x + "-z:" + z + ":1";
                    s.AddComponent<Teren>();
                    s.GetComponent<Teren>().CreateDetail(new Vector3(x1, y1, z1), new Vector3(x2, y2, z2), new Vector3(x3, y3, z3), new Vector3(x4, y4, z4), new Vector2(x, z));
                    TerenCentral.addTerrain(s);
                    s.AddComponent<Rigidbody>();
                    s.GetComponent<Rigidbody>().useGravity = false;
                    s.GetComponent<Rigidbody>().isKinematic = true;
                    s.transform.parent = gameObject.transform;
                    MeshFilter mf = s.GetComponent<MeshFilter>();
                    s.layer = LayerMask.NameToLayer("Terrain");
                    MeshCollider mc = s.AddComponent<MeshCollider>() as MeshCollider;
                    mc.sharedMesh = mf.mesh;
                    mc.convex = false;
                    s.AddComponent<NavMeshSurface>();
                    MaterialStorage.Teren.Add(s);
                    if (z >= 1)
                    {
                        s.transform.localPosition = new Vector3(0.5f, s.transform.localPosition.y, s.transform.localPosition.z - 1 * z);
                    }
                    s.transform.localScale = new Vector3(1, 1, 1);
                }

                catch (Exception e)
                {
                }
            }
        }
    }

    public void GenerateTerrainUnderground(int width, int height, float multiplier)
    {
        int xSize = width;
        int zSize = height;
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];
        for (int i = 0, y = 0; y <= zSize; y++)
        {
            for (int x = 0; x <= xSize; x++, i++)
            {
                vertices[i] = new Vector3(x, y);
            }
        }

        float y1 = 0;
        float y2 = 0;
        float y3 = 0;
        float y4 = 0;
        GameObject g, s;

        for (int z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {   //vlevo
                //1vlevo naho�e, 2vpravo  naho�e, 3 vlevo dole, 4 vpravo dole ;
                int x1 = x + 0;
                int z1 = z + 0;
                int x2 = x;
                int z2 = z + 2;
                int x3 = x + 2;
                int z3 = z;
                int x4 = x + 2;
                int z4 = z + 2;
                try
                {

                    if (x == 0 && z != 0)
                    {
                        x1 = x + 0;
                        x2 = x;
                        z2 = z + 1;
                        x3 = x + 0;
                        z3 = z;
                        x4 = x + 0;
                        z4 = z + 1;
                        y1 = GenerateNois.map[x1, z1];
                        y2 = GenerateNois.map[x2, z2];
                        y3 = -5;
                        y4 = -5;
                        y1 *= multiplier;
                        y2 *= multiplier;
                        y3 *= multiplier;
                        y4 *= multiplier;
                        // continue;
                        s = Instantiate(preFab, new Vector3(x + 0.0f, 0, z), Quaternion.identity);
                        s.GetComponent<TriangleDraw>().DrawPlane(x2, y2, z2, x1, y1, z1, x4, y4, z4, x3, y3, z3);
                        s.name = "Pozdzemi1 x:" + x + "-z:" + z + ":1";
                        if (x1 == 0 && z1 == 1)
                        {

                        }
                        s.AddComponent<Teren>();
                        s.GetComponent<Teren>().CreateDetail(new Vector3(x1, y1, z1), new Vector3(x2, y2, z2), new Vector3(x3, y3, z3), new Vector3(x4, y4, z4), new Vector2(x, z), true);
                        TerenCentral.addTerrain(s);
                        s.AddComponent<Rigidbody>();
                        s.GetComponent<Rigidbody>().useGravity = false;
                        s.GetComponent<Rigidbody>().isKinematic = true;
                        s.transform.parent = gameObject.transform;
                        MeshFilter mf = s.GetComponent<MeshFilter>();
                        s.layer = LayerMask.NameToLayer("Terrain");
                        MeshCollider mc = s.AddComponent<MeshCollider>() as MeshCollider;
                        mc.sharedMesh = mf.mesh;
                        mc.convex = false;
                        s.AddComponent<NavMeshSurface>();
                        MaterialStorage.Teren.Add(s);
                        s.transform.localPosition = new Vector3(0.69f, s.transform.localPosition.y + 0.25f, s.transform.localPosition.z - 1 * z);
                        s.transform.localScale = new Vector3(1, 1, 1);
                    }
                    else if (x == xSize && z != 0)
                    {
                        x1 = x + 0;
                        x2 = x;
                        z2 = z + 1;
                        x3 = x + 1;
                        z3 = z;
                        x4 = x + 1;
                        z4 = z + 1;
                        y1 = GenerateNois.map[x1 - 1, z1];
                        y2 = GenerateNois.map[x2 - 1, z2];
                        y3 = -5;
                        y4 = -5;
                        y1 *= multiplier;
                        y2 *= multiplier;
                        y3 *= multiplier;
                        y4 *= multiplier;
                        s = Instantiate(preFab, new Vector3(x + 0.0f, 0, z), Quaternion.identity);
                        s.GetComponent<TriangleDraw>().DrawPlane(x1, y1, z1, x2, y2, z2, x3, y3, z3, x4, y4, z4);
                        if (x1 == 0 && z1 == 0)
                        {

                        }
                        s.name = "Pozdzemi2 x:" + x + "-z:" + z + ":1";
                        s.AddComponent<Teren>();
                        s.GetComponent<Teren>().CreateDetail(new Vector3(x1, y1, z1), new Vector3(x2, y2, z2), new Vector3(x3, y3, z3), new Vector3(x4, y4, z4), new Vector2(x, z), true);
                        TerenCentral.addTerrain(s);
                        s.AddComponent<Rigidbody>();
                        s.GetComponent<Rigidbody>().useGravity = false;
                        s.GetComponent<Rigidbody>().isKinematic = true;
                        s.transform.parent = gameObject.transform;
                        MeshFilter mf = s.GetComponent<MeshFilter>();
                        s.layer = LayerMask.NameToLayer("Terrain");
                        MeshCollider mc = s.AddComponent<MeshCollider>() as MeshCollider;
                        mc.sharedMesh = mf.mesh;
                        mc.convex = false;
                        s.AddComponent<NavMeshSurface>();
                        MaterialStorage.Teren.Add(s);
                        s.transform.localPosition = new Vector3(-1f, s.transform.localPosition.y - 0.0f, s.transform.localPosition.z - 1 * z);
                        s.transform.localScale = new Vector3(1, 1, 1);
                    }

                    if (z == 0)
                    {
                        //1vlevo naho�e, 2vpravo  naho�e, 3 vlevo dole, 4 vpravo dole ;
                        x1 = x + 1;
                        z1 = z + 1;
                        x2 = x + 0;
                        z2 = z + 1;
                        x3 = x + 1;
                        z3 = z;
                        x4 = x + 0;
                        z4 = z + 0;
                        y1 = GenerateNois.map[x1, z1];
                        y2 = GenerateNois.map[x2, z2];
                        y3 = -5;
                        y4 = -5;
                        y1 *= multiplier;
                        y2 *= multiplier;
                        y3 *= multiplier;
                        y4 *= multiplier;
                        s = Instantiate(preFab, new Vector3(x + 0.0f, 0, z), Quaternion.identity);
                        s.GetComponent<TriangleDraw>().DrawPlane(x2, y2, z2, x1, y1, z1, x4, y4, z4, x3, y3, z3);
                        if (x1 == 0 && z1 == 0)
                        {

                        }
                        s.name = "Pozdzemi3 x:" + x + "-z:" + z + ":1";
                        s.AddComponent<Teren>();
                        s.GetComponent<Teren>().CreateDetail(new Vector3(x1, y1, z1), new Vector3(x2, y2, z2), new Vector3(x3, y3, z3), new Vector3(x4, y4, z4), new Vector2(x, z), true);
                        TerenCentral.addTerrain(s);
                        s.AddComponent<Rigidbody>();
                        s.GetComponent<Rigidbody>().useGravity = false;
                        s.GetComponent<Rigidbody>().isKinematic = true;
                        s.transform.parent = gameObject.transform;
                        MeshFilter mf = s.GetComponent<MeshFilter>();
                        s.layer = LayerMask.NameToLayer("Terrain");
                        s.AddComponent<NavMeshSurface>();
                        MaterialStorage.Teren.Add(s);
                        s.transform.localPosition = new Vector3(0.5f, s.transform.localPosition.y + 0.26f, s.transform.localPosition.z - 1 * z);
                        s.transform.localScale = new Vector3(1, 1, 1);
                    }
                    else if (z == zSize - 1)
                    {
                        //1vlevo naho�e, 2vpravo  naho�e, 3 vlevo dole, 4 vpravo dole ;
                        x1 = x + 1;
                        z1 = z + 1;
                        x2 = x + 0;
                        z2 = z + 1;
                        x3 = x + 1;
                        z3 = z;
                        x4 = x + 0;
                        z4 = z + 0;
                        y1 = GenerateNois.map[x1, z1 - 1];
                        y2 = GenerateNois.map[x2, z2 - 1];
                        y3 = -5;
                        y4 = -5;
                        y1 *= multiplier;
                        y2 *= multiplier;
                        y3 *= multiplier;
                        y4 *= multiplier;
                        if (x1 == 0 && z1 == 0)
                        {

                        }
                        s = Instantiate(preFab, new Vector3(x + 0.0f, 0, z), Quaternion.identity);
                        s.GetComponent<TriangleDraw>().DrawPlane(x1, y1, z1, x2, y2, z2, x3, y3, z3, x4, y4, z4);
                        s.name = "Pozdzemi4 x:" + x + "-z:" + z + ":1";
                        s.AddComponent<Teren>();
                        s.GetComponent<Teren>().CreateDetail(new Vector3(x1, y1, z1), new Vector3(x2, y2, z2), new Vector3(x3, y3, z3), new Vector3(x4, y4, z4), new Vector2(x, z), true);
                        TerenCentral.addTerrain(s);
                        s.AddComponent<Rigidbody>();
                        s.GetComponent<Rigidbody>().useGravity = false;
                        s.GetComponent<Rigidbody>().isKinematic = true;
                        s.transform.parent = gameObject.transform;
                        MeshFilter mf = s.GetComponent<MeshFilter>();
                        s.layer = LayerMask.NameToLayer("Terrain");
                        s.AddComponent<NavMeshSurface>();
                        MaterialStorage.Teren.Add(s);
                        s.transform.localPosition = new Vector3(0.5f, s.transform.localPosition.y + 0.26f, -1);
                        s.transform.localScale = new Vector3(1, 1, 1);
                    }
                    else
                    {
                        continue;
                    }
                }

                catch (Exception e)
                {
                }
            }
        }
    }
}
