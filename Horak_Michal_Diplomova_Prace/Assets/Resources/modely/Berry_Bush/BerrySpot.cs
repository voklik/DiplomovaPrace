using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerrySpot : MonoBehaviour
{
    //Tato tøída slouží jako bod, kdese generují plody. Napøíklad bobule na keøi.
    [SerializeField] private GameObject prefabBerry;
    [SerializeField] private GameObject berry = null;
    [SerializeField] private float timeForNewBerry = 10.0f;
    [SerializeField] private float leftTimeForNewBerry = 0.0f;
    [SerializeField] private bool berryisDead = true;
    // Start is called before the first frame update
    void Start()
    {
        prefabBerry =  Resources.Load<GameObject>("modely/Berry_Bush/Berry");
       
    }

    // Update is called once per frame
    void Update()
    {
    if(berryisDead==true)
        {
            leftTimeForNewBerry += Time.deltaTime;
            if(leftTimeForNewBerry>= timeForNewBerry)
            {
                SpawnBerry();
                leftTimeForNewBerry = 0.0f;
            }

         }
    }

    public void BerryIsDead()
    {
        berry = null;
        berryisDead = true;

    }
    private void SpawnBerry()
    {
        berry = Instantiate(prefabBerry, transform.position, Quaternion.identity);
        berry.transform.parent = gameObject.transform;
        berry.transform.localPosition = transform.localPosition; //new Vector3(0.0f, 0.0f, 0.0f);
        // berry.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        berry.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        berry.GetComponent<Berry>().SetBerrySpot(this);
        berry.name = "berry";
        berryisDead = false;
    }
}
