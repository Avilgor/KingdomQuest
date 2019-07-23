using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class ShowRanking : MonoBehaviour
{
    [SerializeField]
    private Text[] posiciones;

    void Start()
    {
        try
        {
            posiciones[0].text = "1:" + DATOS.Ranking.ElementAt(0).nombre + "--" + DATOS.Ranking.ElementAt(0).puntos;
            posiciones[1].text = "2:" + DATOS.Ranking.ElementAt(1).nombre + "--" + DATOS.Ranking.ElementAt(1).puntos;
            posiciones[2].text = "3:" + DATOS.Ranking.ElementAt(2).nombre + "--" + DATOS.Ranking.ElementAt(2).puntos;
            posiciones[3].text = "4:" + DATOS.Ranking.ElementAt(3).nombre + "--" + DATOS.Ranking.ElementAt(3).puntos;
            posiciones[4].text = "5:" + DATOS.Ranking.ElementAt(4).nombre + "--" + DATOS.Ranking.ElementAt(4).puntos;
        } catch (Exception e)
        {

        }        
    }
}