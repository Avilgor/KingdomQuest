using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using System;

public static class EscribirFichero
{      
    public static void WriteResults(string user,string personaje,int puntos)
    {
        try
        {
            string path = Application.dataPath + "/StreamingAssets/Historial.txt";
            StreamWriter sw = new StreamWriter(path, true);

            if (!File.Exists(path))
            {
                File.Create(path);
                sw.WriteLine("--Historial de partidas--");
            }

            sw.WriteLine(user + " : " + personaje + "/" + puntos);
            sw.Close();

            Debug.Log("Datos de partida guardados.");
        }catch(Exception e)
        {
            Debug.Log(e);
        }      
    }
}