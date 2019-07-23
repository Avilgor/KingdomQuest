using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorRanking 
{
    public int puntos = 0;
    public string nombre = "";
    public JugadorRanking(string name,int points)
    {
        puntos = points;
        nombre = name;
    }   
}