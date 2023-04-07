using System.Collections.Generic;
using UnityEngine;

public class GenerateObject : MonoBehaviour
{
    // T��da, kter� slou�� pro vytv��en� nov�ch zv��at, �i rostlin. 
    // samice rod� pomoc� tohoto gener�toru, aby se k�d nevyskytoval v�cekr�t.
    private static List<ItemID> Listid = new List<ItemID>();

    public List<Entity> GenerateEntityPopulation(string kind, int count, Vector3 teren)
    {
        int malecount = count / 2;
        List<Entity> news = new List<Entity>();
        GameObject entita = Resources.Load<GameObject>(kind) as GameObject;
        for (int i = 1; i <= count; i++)
        {
            if (teren == Vector3.zero)
            {
                if (malecount > 0)
                {
                    news.Add(GenerateEntity(entita, GetPosition(), kind));
                    malecount--;
                }
                else
                    news.Add(GenerateEntity(entita, GetPosition(), kind));
            }
            else
            {
                if (malecount > 0)
                {
                    news.Add(GenerateEntity(entita, teren, kind));
                    malecount--;
                }
                else
                    news.Add(GenerateEntity(entita, teren, kind));


            }


        }
        return news;
    }

    private static Entity GenerateEntity(GameObject g, Vector3 position, string kind)
    {
        try
        {
            GameObject novy;

            novy = Instantiate(g, position, Quaternion.identity);

            if (novy == null)
                Debug.LogError("nenalezeno " + kind);

            bool ismale;
            int id = CheckID(kind, out ismale);
            novy.name = kind + "-" + +id;
            novy.GetComponent<Entity>().SetID(id);
            novy.GetComponent<Entity>().SetIsMale(ismale);
            novy.GetComponent<Entity>().SetKind("kind");
            return novy.GetComponent<Entity>();
        }
        catch (System.Exception)
        {
            Debug.LogError("ERROR BORNING " + kind);
            return null;
        }
    }

    private static Vector3 GetPosition()
    {
        //Metoda, kter� vybere random pozici. Vyu�ito pro �vodn� generov�n� po��te�n� populace.
        float x = Mathf.Round(Random.Range(3, WorldGenerateSettings.Width - 3));
        float z = Mathf.Round(Random.Range(3, WorldGenerateSettings.Depth - 3));
        //GameObject teren = MaterialStorage.Teren[(int)((Mathf.Round(z) * (float)(WorldGenerateSettings.Width)) + Mathf.Round(x))];
        try
        {
            GameObject teren = MaterialStorage.Teren[Random.Range(3, MaterialStorage.Teren.Count - 1)];
            float y = teren.GetComponent<Teren>().GetDetail().vertex1.y + 2.0f;




            return new Vector3(x, y, z);
        }
        catch (System.Exception)
        {

            return GetPosition();
        }

    }

    private static int CheckID(string kind, out bool isMale)
    {
        //kontrola, jestli existuje takov� druh. V p��pad�, �e ano, tak vr�t� nov� ID pro entitu a zda se jedn� o samce. 
        //V p��pad�, �e ne, tak ten druh vytvo�� a vr�t� �daje.
        bool founded = false;
        isMale = false;
        int id = -2;
        foreach (ItemID item in Listid)
        {
            if (item.GetText().Equals(kind))
            {
                founded = true;
                item.IncreaseNumber();
                id = item.GetNumber();
                isMale = item.GetnextGender();
                item.ChangeNextGender();
                break;
            }
        }
        if (founded == false)
        {
            ItemID item = new ItemID(kind, 1, false);
            Listid.Add(item);
            item.ChangeNextGender();
            isMale = true;
            id = 1;
        }
        return id;
    }
}
