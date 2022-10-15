using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Teren : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //Tøída, která reprezentuje ètvercovou plochu + Provádí nastavení barvy plochy
    private TerenDetail terenDetail;

    public void CreateDetail(Vector3 a, Vector3 b, Vector3 c, Vector3 d, Vector2 position)
    {
        terenDetail = new TerenDetail(a, b, c, d, position);
    }

    public void SetInit(GameObject waterPrefabPlane)
    {
        Vector3 a = terenDetail.vertex1;
       // Debug.LogError(a.y+".§"+WorldGenerateSettings.Multiplier.ToString() + "-"+ (0.2 * WorldGenerateSettings.Multiplier).ToString());
        gameObject.tag = "terrain";
        //if (a.y > 0.2 * WorldGenerateSettings.Multiplier && a.y < 0.8 * WorldGenerateSettings.Multiplier)

        if (a.y >= WorldGenerateSettings.BaseMaxHeight * 0.6f && a.y <= 0.85f * WorldGenerateSettings.BaseMaxHeight)
        //   this.GetComponent<MeshFilter>().mesh
        //GetComponent<Renderer>().material = MaterialStorage.earth;
        //gameObject.GetComponent<MeshRenderer>().material = MaterialStorage.earth;
        {
            gameObject.GetComponent<Renderer>().material.color = MaterialStorage.Earth;
            GameObject g = Instantiate(MaterialStorage.EarthPointPreFab, new Vector3(a.x * 1, a.y + 0.5f, a.z * 1), Quaternion.identity);
            g.transform.parent = gameObject.transform;
            g.name = "EarthPoint" + gameObject.name;
            g.tag = "terrain";
            g.transform.localPosition = new Vector3(a.x * 1, a.y + 0.1f, a.z * 1);
          //  Debug.LogError(a.y +"> "+1.4f * WorldGenerateSettings.baseHeight +"> Earth <" + 0.8 * WorldGenerateSettings.BaseMaxHeight);
        }


        else if (a.y >= 0.85 * WorldGenerateSettings.BaseMaxHeight )
        {
            gameObject.GetComponent<Renderer>().material.color = MaterialStorage.Stone;

            GameObject g = Instantiate(MaterialStorage.EarthPointPreFab, new Vector3(a.x * 1, a.y + 0.1f, a.z * 1), Quaternion.identity);
            g.transform.parent = gameObject.transform;
            g.name = "EarthPoint";// + gameObject.name;
            g.tag = "terrain";
            g.transform.localPosition = new Vector3(a.x * 1, a.y + 0.1f, a.z * 1);
         //   Debug.LogError(a.y + "Stone >"+ 0.8 * WorldGenerateSettings.BaseMaxHeight);
        }

        else if (a.y<WorldGenerateSettings.BaseMaxHeight * 0.6f)
        {
           // Debug.LogError(a.y + "Sand <" +WorldGenerateSettings.baseHeight);
            gameObject.GetComponent<Renderer>().material.color = MaterialStorage.Sand;
            // GameObject s = Instantiate(MaterialStorage.waterPointPreFab, new Vector3(gameObject.transform.position.x, a.y + 0.5f, gameObject.transform.position.z), Quaternion.identity);

            //GameObject s = Instantiate(MaterialStorage.waterPointPreFab, new Vector3(a.x * 1, a.y + 0.5f, a.z * 1), Quaternion.identity);

            //if (gameObject.name.EndsWith("1"))
            //{
            //    s.transform.localPosition = new Vector3((a.x * 1) - 1, a.y + 0.01f, (a.z * 1) + 0.5f);
            //}
            //else
            //{

            //    s.transform.localPosition = new Vector3((a.x * 1) - 3 + 0.5f, a.y + 0.01f, (a.z * 1) + 1 + 0.5f);
            //}
            //s.transform.parent = gameObject.transform;

            //s.tag = "water";
            GameObject g = Instantiate(MaterialStorage.waterPointPreFab, new Vector3(0, 0, 0), Quaternion.identity);

           
            g.transform.parent = gameObject.transform;
            if (gameObject.name.EndsWith("1"))
            {
                g.transform.localPosition = new Vector3(a.x * 1, a.y + 0.1f, a.z * 1);
                //g.transform.localPosition = new Vector3(0.5f, a.y + 1.0f, (a.z * 1));
            }
            else
            {
                g.transform.localPosition = new Vector3(a.x * 1, WorldGenerateSettings.BaseMaxHeight * 0.6f, a.z * 1);
               // g.transform.localPosition = new Vector3(+0.5f, a.y + 1.0f, (a.z * 1));
            }
            g.tag = "water";
            GameObject b = Instantiate(waterPrefabPlane, new Vector3(0, 0, 0), Quaternion.identity);

            b.transform.localScale = new Vector3(0.20f,0, 0.30f);
            b.transform.parent = gameObject.transform;
            b.name = "WaterPlane";
            b.transform.localPosition = new Vector3(a.x * 1, WorldGenerateSettings.BaseMaxHeight * 0.58f, a.z * 1+0.8f);
            b.tag = "water";
        }
    }
  

    public void SetBanare(float height)
    {
        //  if (terenDetail.position.y * MaterialStorage.Multiplier < height)
        if (gameObject.GetComponent<Renderer>().material.color == MaterialStorage.Sand)
        {
            //   gameObject.GetComponent<NavMeshModifierVolume>().area = 2;
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
        //Output to console the GameObject's name and the following message
        Debug.Log("Cursor Entering " + name + " GameObject");
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        //Output the following message with the GameObject's name
        Debug.Log("Cursor Exiting " + name + " GameObject");
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
         //   MaterialStorage.toolltipUI.DisplayInfo(terenDetail.vertex1.ToString());
        }
    }
}
