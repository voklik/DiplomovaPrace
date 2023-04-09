using System.Collections.Generic;
using UnityEngine;

public class TerenCentral : MonoBehaviour
{
    //Tøída, která slouží jako seznam listù pro Terény
    public static readonly List<GameObject> teren = new List<GameObject>();
    public static void addTerrain(GameObject g)
    {
        teren.Add(g);
    }

    public static GameObject GetTeren(int x, int z)
    {
        foreach (GameObject game in teren)
        {
            if (game.GetComponent<TerenDetail>().vertex1.x == x && game.GetComponent<TerenDetail>().vertex1.z == z
                || game.GetComponent<TerenDetail>().vertex2.x == x && game.GetComponent<TerenDetail>().vertex2.z == z
                || game.GetComponent<TerenDetail>().vertex3.x == x && game.GetComponent<TerenDetail>().vertex3.z == z)
                return game;
        }
        return null;
    }

    public static void RemoveTeren(GameObject g)
    {
        try
        {
            teren.Remove(g);
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}
