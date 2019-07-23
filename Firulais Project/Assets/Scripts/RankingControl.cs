using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;

public static class RankingControl 
{   
    static string path = Application.dataPath + "/StreamingAssets/Ranking.txt";

    public static List<JugadorRanking> doList()
    {
        List<JugadorRanking> lista = new List<JugadorRanking>();
        List<JugadorRanking> ordenadaLista = new List<JugadorRanking>();
        try
        {
            String[] results = new string[3];
            StreamReader reader = new StreamReader(path);
            LeeLinea(reader);
            for (int i = 0; i < 5; i++)
            {
            results = LeeLinea(reader).Split('/');
                JugadorRanking a = new JugadorRanking(results[1], Int32.Parse(results[2]));
                lista.Add(a);                  
            }
            reader.Close();
            ordenadaLista = lista.OrderByDescending(o => o.puntos).ToList();         
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        return ordenadaLista;
    }

    static String LeeLinea(StreamReader read)
    {     
        String leido = "";        
        try
        {
            leido = read.ReadLine();           
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }                     
        return leido;
    }

    public static void VerificarRanking(String jugador, int puntuacion)
    {
        List<JugadorRanking> Lista = new List<JugadorRanking>();
        File.Delete(path);

        StreamWriter write = new StreamWriter(path, true);
        JugadorRanking player = new JugadorRanking(jugador, puntuacion);
        DATOS.Ranking.Add(player);

        Lista = DATOS.Ranking.OrderByDescending(o => o.puntos).ToList();
        Lista.RemoveAt(5);            

        write.WriteLine("--Ranking--");
        write.WriteLine("1/" + Lista.ElementAt(0).nombre + "/" + Lista.ElementAt(0).puntos);
        write.WriteLine("2/" + Lista.ElementAt(1).nombre + "/" + Lista.ElementAt(1).puntos);
        write.WriteLine("3/" + Lista.ElementAt(2).nombre + "/" + Lista.ElementAt(2).puntos);
        write.WriteLine("4/" + Lista.ElementAt(3).nombre + "/" + Lista.ElementAt(3).puntos);
        write.WriteLine("5/" + Lista.ElementAt(4).nombre + "/" + Lista.ElementAt(4).puntos);
        write.Close();
    }

    public static void RankingBDD(String jugador, int puntuacion)
    {
        List<JugadorRanking> Lista = new List<JugadorRanking>();

        JugadorRanking player = new JugadorRanking(jugador, puntuacion);
        DATOS.Ranking.Add(player);

        Lista = DATOS.Ranking.OrderByDescending(o => o.puntos).ToList();
        Lista.RemoveAt(5);
    }
}