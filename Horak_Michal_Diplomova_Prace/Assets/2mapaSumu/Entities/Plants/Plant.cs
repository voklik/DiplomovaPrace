using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Plant : Entity
{
    public void InitHeightReset()
    {
        InitHeight2();
    }

    public override void Start()
    {
        typeEntity = 2;
        Init();

        gameObject.GetComponentInChildren<Rigidbody>().useGravity = true;
        gameObject.GetComponentInChildren<Rigidbody>().angularDrag = 100;
    }
    public override void Update()
    {
        if (isLive)
        {
            StatsChangeTimeEntity();
        }

        Reproduce();
        transform.rotation = Quaternion.Euler(0, 0, 0);
        Wait(0.5f);
    }

    private void Reproduce()
    {
        if (age >= mature_age && canReproduce == true)
        {
            if (reproduce_cooldown_left > 0)
            {
                reproduce_cooldown_left -= Time.deltaTime;
            }
            else
            {
                Vector3 teren = new Vector3(Random.Range(1, 3) + gameObject.transform.position.x
                    , gameObject.transform.position.y,
                    Random.Range(0, 1) + gameObject.transform.position.z);
                //pokud to není keø
                if (type != 3)
                {
                    MaterialStorage.generator.GenerateEntityPopulation(kind, 1, teren);
                    reproduce_cooldown_left = reproduce_cooldown;
                }
            }
        }
    }
    public override string GetEntityInformation()
    {
        string text = "";
        text += kind + " " + name + " " + Mathf.Round(age * 10) / 10 + " ";
        return text;
    }
}
