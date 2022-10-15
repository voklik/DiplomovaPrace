using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExportDataRow 
{

    public List<string> Columns = new List<string>();

    public ExportDataRow(List<string> columns)
    {
        Columns = columns;
    }

    public string CSVFormat()
    {
        string text = "";

        foreach (string item in Columns)
        {
            text += item + ",";
        }
        return text;
    }

}
