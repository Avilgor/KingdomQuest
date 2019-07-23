using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    float tempo = 0;
    void Start()
    {
        int longitud;
        if (DATOS.jugador.Length > 15)
        {
            longitud = 10;
        }
        else
        {
            longitud = DATOS.jugador.Length;
        }

        string player = DATOS.jugador.Substring(0,longitud);

        RankingControl.VerificarRanking(player, DATOS.puntuacion);

        string texto = player+"/"+DATOS.puntuacion;
        EscribirFichero.WriteResults(player, DATOS.personaje.name, DATOS.puntuacion);
        /* try //Prueba base de datos
         {

             ConnectServer connection = new ConnectServer();
             connection.InsertHistorial(texto);
             ConnectServer connection2 = new ConnectServer();
             connection2.InsertRanking(texto);

         }
         catch (Exception e) //Escribe en fichero local si falla
         {
             EscribirFichero.WriteResults(player, DATOS.personaje.name, DATOS.puntuacion);           
         }*/

        //connection.InsertRanking(texto);
    }

    void Update ()
    {
        tempo += Time.deltaTime;
        if (tempo > 3)
        {
            DATOS.vidas = 3;
            DATOS.puntuacion = 500;
            SceneManager.LoadScene("Menu");
        }
    }
}