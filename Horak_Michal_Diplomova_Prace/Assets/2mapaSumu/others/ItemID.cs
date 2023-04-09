public class ItemID
{
    /*Pomocná tøída, která se pouívá pøi generování nového èlena populace. 
  * Zajišuje rovnomìrné zastoupení samcù a samic v populaci
    */
    private string text;
    private int number;
    private bool wasLastMale;

    public ItemID(string text, int number, bool wasLastMale)
    {
        this.text = text;
        this.number = number;
        this.wasLastMale = wasLastMale;
    }

    public string GetText()
    {
        return text;
    }

    public void SetText(string t)
    {
        text = t;
    }

    public int GetNumber()
    {
        return number;
    }

    public void SetNumber(int n)
    {
        number = n;
    }

    public void IncreaseNumber()
    {
        number += 1;
    }

    public bool GetnextGender()
    {
        return !wasLastMale;
    }

    public void ChangeNextGender()
    {
        wasLastMale = !wasLastMale;
    }
}
