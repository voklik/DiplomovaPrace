using UnityEngine;
using UnityEngine.UI;

public class UIStatWindow : MonoBehaviour
{
    //B�hem simulace je informa�n� okno napravo a pr�v� toto okno z�sk�v� informace odtud
    int typeInfo = 0;

    [SerializeField] private Text TextField;

    [SerializeField] private GameObject Container;

    private void OnEnable()
    {
        if (TextField != null)
        {
            TextField.text = StatisticSystem.StatisticEventLog();
        }
        typeInfo = 1;
        SetHeight();
    }

    public void SetWindowStatisticsEvent()
    {
        //Vypi� ud�losti entit > narozen�, nalezen� partnera, smrt a atd.
        typeInfo = 1;
        if (TextField != null)
        {
            TextField.text = StatisticSystem.StatisticEventLog();
        }
        SetHeight();
    }

    public void SetWindowListOfAnimal()
    {
        //Vypi� jenom zv��ata
        typeInfo = 2;
        if (TextField != null)
        {
            TextField.text = StatisticSystem.StatisticLiveAnimal();
        }
        SetHeight();
    }

    public void SetWindowListOfPlant()
    {
        //Vypi� jenom rostliny
        typeInfo = 3;
        if (TextField != null)
        {
            TextField.text = StatisticSystem.StatisticLivePlants();
        }
        SetHeight();
    }

    public void SetWindowKindStatistics()
    {
        //Vypi� stav druh� (kolik jich pr�v� �ije a kolik zem�elo)
        typeInfo = 4;
        if (TextField != null)
        {
            TextField.text = StatisticSystem.StatisticKindLog();
        }
        SetHeight();
    }

    public void ResetInformation()
    {
        //obnov� informace v okn�
        switch (typeInfo)
        {
            default:
                SetWindowStatisticsEvent();
                break;
            case 1:
                SetWindowStatisticsEvent();
                break;
            case 2:
                SetWindowListOfAnimal();
                break;
            case 3:
                SetWindowListOfPlant();
                break;
            case 4:
                SetWindowKindStatistics();
                break;


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
