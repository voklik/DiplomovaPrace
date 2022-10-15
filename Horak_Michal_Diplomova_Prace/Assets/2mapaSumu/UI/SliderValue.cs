using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{
    //T��da, kter� za�izuje to, �e p�i zm�n� hodnoty slideru se zm�n� i text, kter� vypisuje hodnotu
    public Slider Slider;

    public Text Text;

    public void Start()
    {
        //Adds a listener to the main slider and invokes a method when the value changes.
        Slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        if (Slider != null & Text != null)
        {
            Text.text = Slider.value.ToString();
        }
    }

    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
        if (Slider != null & Text != null)
        {
            Text.text = Slider.value.ToString();
        }
    }
}
