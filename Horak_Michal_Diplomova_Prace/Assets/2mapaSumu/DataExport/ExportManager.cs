using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using System;
using System.Diagnostics;

public class ExportManager : MonoBehaviour
{
    /// <summary>
    /// Tøída, která se postará o o export, poud se stiskne mezerník
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CheckExistingFolder())
            {
                ExportAllLive();
                ExportKinds();
                ExportKindsOverTime();
                ExportEvents();
                OpenFolder();

            }

            //  testAdd();
        }
    }
    private string FolderName = @"\ExportFolder", FileName = "Export", TypeName = ".csv";
    public bool CheckExistingFolder()
    {
        var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var path = Path.Combine(appDataPath, @"SimulatorExportDat\");
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        return Directory.Exists(path);
    }

    public bool testAdd()
    {
        var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var path = Path.Combine(appDataPath, @"SimulatorExportDat\");
        List<ExportDataRow> list = new List<ExportDataRow>();
        for (int i = 0; i < 10; i++)
        {
            List<string> seznam = new List<string>();
            for (int z = 0; z < 10; z++)
            {
                seznam.Add(i + "" + z);
            }
            ExportDataRow data = new ExportDataRow(seznam);
            list.Add(data);
        }

        WriteCSV(list, path, "existence");
        OpenFolder();
        return false;
    }

    public void OpenFolder()
    {
        var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var path = Path.Combine(appDataPath, @"SimulatorExportDat\");
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            Arguments = path,
            FileName = "explorer.exe"
        };


        Process.Start(startInfo);
    }

    private void WriteCSV(List<ExportDataRow> list, string path, string fileName)
    {
        string FinalFileName = path + "\\" + fileName + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString() + TypeName;

        using (var w = new StreamWriter(FinalFileName))
        {


            foreach (ExportDataRow item in list)
            {
                w.WriteLine(string.Join("&", item.CSVFormat()));
            }

            w.Flush();
        }



    }

    public void ExportKindsOverTime()
    {
        var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var path = Path.Combine(appDataPath, @"SimulatorExportDat\");
        CheckExistingFolder();
        WriteCSV(StatisticSystem.ExportRowsKindsOverTime(), path, "KindsOverTime");

    }
    public void ExportKinds()
    {
        var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var path = Path.Combine(appDataPath, @"SimulatorExportDat\");
        CheckExistingFolder();
        WriteCSV(StatisticSystem.ExportRowsKindsActual(), path, "Kinds");
    }
    public void ExportAllLive()
    {
        var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var path = Path.Combine(appDataPath, @"SimulatorExportDat\");
        CheckExistingFolder();
        WriteCSV(StatisticSystem.ExportRowsAllLives(), path, "AllLives");
    }
    public void ExportEvents()
    {
        var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var path = Path.Combine(appDataPath, @"SimulatorExportDat\");
        CheckExistingFolder();
        WriteCSV(StatisticSystem.ExportRowsEvents(), path, "Events");
    }

}




