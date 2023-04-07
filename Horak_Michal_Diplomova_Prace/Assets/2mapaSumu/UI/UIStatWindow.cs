using UnityEngine;
using UnityEngine.UI;

public class UIStatWindow : MonoBehaviour
{
    //B�hem simulace je informa�n� okno napravo a pr�v� toto okno z�sk�v� informace odtud

    [SerializeField] private Text TextField;

    [SerializeField] private GameObject Container;

    private void OnEnable()
    {
        if (TextField != null)
        {
            TextField.text = StatisticSystem.StatisticEventLog();
        }
        SetHeight();
    }

    public void SetWindowStatisticsEvent()
    {
        //Vypi� ud�losti entit > narozen�, nalezen� partnera, smrt a atd.
        
        if (TextField != null)
        {
            TextField.text = StatisticSystem.StatisticEventLog();
        }
        SetHeight();
    }

    public void SetWindowListOfAnimal()
    {
        //Vypi� jenom zv��ata
        if (TextField != null)
        {
            TextField.text = StatisticSystem.StatisticLiveAnimal();
        }
        SetHeight();
    }

    public void SetWindowListOfPlant()
    {
        //Vypi� jenom rostliny
        if (TextField != null)
        {
            TextField.text = StatisticSystem.StatisticLivePlants();
        }
        SetHeight();
    }

    public void SetWindowKindStatistics()
    {
        //Vypi� stav druh� (kolik jich pr�v� �ije a kolik zem�elo)
        if (TextField != null)
        {
            TextField.text = StatisticSystem.StatisticKindLog();
        }
        SetHeight();
    }

    public void IncreaseFontSize()
    {
        TextField.fontSize += 1;
    }

    public void DecreaseFontSize()
    {
        TextField.fontSize -= 1;
    }

    private void SetHeight()
    {

        //Za�izuje to, �e po zm�n� str�nky se scroluje na za��tek
        Container.transform.localPosition = new Vector3(Container.transform.localPosition.x, -5000, Container.transform.localPosition.z);
    }
}
