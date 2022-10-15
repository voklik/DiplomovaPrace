using UnityEngine;
using UnityEngine.UI;

public class UIStatWindow : MonoBehaviour
{
    //Bìhem simulace je informaèní okno napravo a právì toto okno získává informace odtud
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
        //Vypiš události entit > narození, nalezení partnera, smrt a atd.
        typeInfo = 1;
        if (TextField != null)
        {
            TextField.text = StatisticSystem.StatisticEventLog();
        }
        SetHeight();
    }

    public void SetWindowListOfAnimal()
    {
        //Vypiš jenom zvíøata
        typeInfo = 2;
        if (TextField != null)
        {
            TextField.text = StatisticSystem.StatisticLiveAnimal();
        }
        SetHeight();
    }

    public void SetWindowListOfPlant()
    {
        //Vypiš jenom rostliny
        typeInfo = 3;
        if (TextField != null)
        {
            TextField.text = StatisticSystem.StatisticLivePlants();
        }
        SetHeight();
    }

    public void SetWindowKindStatistics()
    {
        //Vypiš stav druhù (kolik jich právì žije a kolik zemøelo)
        typeInfo = 4;
        if (TextField != null)
        {
            TextField.text = StatisticSystem.StatisticKindLog();
        }
        SetHeight();
    }

    public void ResetInformation()
    {
        //obnoví informace v oknì
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

        //Zaøizuje to, že po zmìnì stránky se scroluje na zaèátek
        Container.transform.localPosition = new Vector3(Container.transform.localPosition.x, -5000, Container.transform.localPosition.z);
    }
}
