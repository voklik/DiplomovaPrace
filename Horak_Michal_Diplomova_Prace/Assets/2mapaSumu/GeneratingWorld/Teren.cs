using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Teren : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //Tøída, která reprezentuje ètvercovou plochu + Provádí nastavení barvy plochy
    private TerenDetail terenDetail;
    public void CreateDetail(Vector3 a, Vector3 b, Vector3 c, Vector3 d, Vector2 position, bool underground = false)
    {
        terenDetail = new TerenDetail(a, b, c, d, position, underground);
    }

    public void SetInit(GameObject waterPrefabPlane)
    {
        Vector3 a = terenDetail.vertex1;
        gameObject.tag = "terrain";
        if (a.y >= WorldGenerateSettings.BaseMaxHeight * 0.6f && a.y <= 0.85f * WorldGenerateSettings.BaseMaxHeight)
        {
            gameObject.GetComponent<Renderer>().material.color = MaterialStorage.Earth;
            GameObject g = Instantiate(MaterialStorage.EarthPointPreFab, new Vector3(a.x * 1, a.y + 0.5f, a.z * 1), Quaternion.identity);
            g.transform.parent = gameObject.transform;
            g.name = "EarthPoint" + gameObject.name;
            g.tag = "terrain";
            g.transform.localPosition = new Vector3(a.x * 1, a.y + 0.1f, a.z * 1);
        }


        else if (a.y >= 0.85 * WorldGenerateSettings.BaseMaxHeight)
        {
            gameObject.GetComponent<Renderer>().material.color = MaterialStorage.Stone;
            GameObject g = Instantiate(MaterialStorage.EarthPointPreFab, new Vector3(a.x * 1, a.y + 0.1f, a.z * 1), Quaternion.identity);
            g.transform.parent = gameObject.transform;
            g.name = "EarthPoint";
            g.tag = "terrain";
            g.transform.localPosition = new Vector3(a.x * 1, a.y + 0.1f, a.z * 1);
        }

        else if (a.y < WorldGenerateSettings.BaseMaxHeight * 0.6f)
        {
            gameObject.GetComponent<Renderer>().material.color = MaterialStorage.Sand;

            GameObject g = Instantiate(MaterialStorage.waterPointPreFab, new Vector3(0, 0, 0), Quaternion.identity);


            g.transform.parent = gameObject.transform;
            if (gameObject.name.EndsWith("1"))
            {
                g.transform.localPosition = new Vector3(a.x * 1, a.y + 0.1f, a.z * 1);
            }
            else
            {
                g.transform.localPosition = new Vector3(a.x * 1, WorldGenerateSettings.BaseMaxHeight * 0.6f, a.z * 1);
            }
            g.tag = "water";
            GameObject b = Instantiate(waterPrefabPlane, new Vector3(0, 0, 0), Quaternion.identity);
            b.transform.localScale = new Vector3(0.20f, 0, 0.30f);
            b.transform.parent = gameObject.transform;
            b.name = "WaterPlane";
            b.transform.localPosition = new Vector3(a.x * 1, WorldGenerateSettings.BaseMaxHeight * 0.58f, a.z * 1 + 0.8f);
            b.tag = "water";
        }
        if (terenDetail.podklad)
        {
            gameObject.GetComponent<Renderer>().material.color = MaterialStorage.Underground;
        }
    }


    public void SetBanare(float height)
    {
        if (gameObject.GetComponent<Renderer>().material.color == MaterialStorage.Sand)
        {
            gameObject.GetComponent<NavMeshSurface>().defaultArea = 2;
            NavMeshObstacle meshObstacle = gameObject.AddComponent<NavMeshObstacle>();
            meshObstacle.carving = true;
        }
    }

    public TerenDetail GetDetail()
    {
        return terenDetail;
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        Debug.Log("Cursor Entering " + name + " GameObject");
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        Debug.Log("Cursor Exiting " + name + " GameObject");
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
        }
    }
}
