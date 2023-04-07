using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExportDataRow
{
    /// <summary>
    /// T��da, kter� zap�e data do .csv
    /// </summary>

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
