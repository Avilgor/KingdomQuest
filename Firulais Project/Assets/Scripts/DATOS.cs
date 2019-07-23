using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DATOS
{
    public static int vidas=0;
    public static int puntuacion=0;
    public static GameObject personaje;
    public static string jugador = "";
    public static bool BKMusic=true;
    public static bool lvlMusic = false;
    public static List<JugadorRanking> Ranking = new List<JugadorRanking>();
}