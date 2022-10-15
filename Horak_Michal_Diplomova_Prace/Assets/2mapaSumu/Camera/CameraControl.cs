using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{//https://www.youtube.com/watch?v=cfjLQrMGEb4&ab_channel=Brackeys
    [SerializeField] private  float PanSpeed = 20f;
    [SerializeField] private  float PanBorderThickness = 10f;
    [SerializeField] private  Vector2  PanLimit=Vector2.zero;
    [SerializeField] float scroll;
    [SerializeField] private  float ScrollSpeed = 20f;
    [SerializeField] private  float MinY = 5f;
    [SerializeField] private  float MaxY = 120f;
  
    // Start is called before the first frame update,
    void Start()
    {
        
        MinY = WorldGenerateSettings.MaxHeinght + 20;
        MaxY = WorldGenerateSettings.MaxHeinght + 40;
        PanLimit = new Vector2( WorldGenerateSettings.Width, WorldGenerateSettings.Depth);
       // this.transform.position = new Vector3(PanLimit.x / 4,  Mathf.Clamp(transform.position.y, MinY, MaxY), PanLimit.y / 4);
        gameObject.transform.position = new Vector3(WorldGenerateSettings.Width / 4, Mathf.Clamp(transform.position.y, MinY, MaxY),0);
        transform.rotation = Quaternion.Euler(33, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if (Input.GetKey("w"))// || Input.mousePosition.y >= Screen.height - PanBorderThickness)
        { pos.z += PanSpeed * Time.unscaledDeltaTime; }
        if (Input.GetKey("s"))// || Input.mousePosition.y <= PanBorderThickness)
        { pos.z -= PanSpeed * Time.unscaledDeltaTime; }
        if (Input.GetKey("d"))// || Input.mousePosition.x >= Screen.width - PanBorderThickness)
        { pos.x += PanSpeed * Time.unscaledDeltaTime; }
        if (Input.GetKey("a"))// || Input.mousePosition.x <= PanBorderThickness)
        { pos.x -= PanSpeed * Time.unscaledDeltaTime; }
        if (Input.GetKey("q"))
        {
            //rotace doleva
           Vector3 rotateValue = new Vector3(0,  -20 * Time.unscaledDeltaTime, 0);
            transform.eulerAngles = transform.eulerAngles - rotateValue;
        }
        if (Input.GetKeyDown("r"))
        {
            //vyresetování úhlu
            Vector3 rotateValue = new Vector3(0, -20 * Time.unscaledDeltaTime, 0);
            transform.rotation = Quaternion.Euler(33, 0, 0);
        }
        if (Input.GetKey("e"))
        {
            //rotace doprava
            Vector3 rotateValue = new Vector3(0,  +20 * Time.unscaledDeltaTime, 0);
            transform.eulerAngles = transform.eulerAngles - rotateValue;
        }
        if (Input.mouseScrollDelta.y > 0)
        { pos.y += ScrollSpeed * Time.unscaledDeltaTime; }
        if (Input.mouseScrollDelta.y < 0)
        { pos.y -= ScrollSpeed * Time.unscaledDeltaTime; }

        //pos.y += scroll * ScrollSpeed * 100f * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, -10, PanLimit.x + 10);
        pos.y = Mathf.Clamp(pos.y, MinY, MaxY);
        pos.z = Mathf.Clamp(pos.z, -10, PanLimit.y + 10);
        transform.position = pos;
    }
  
}
