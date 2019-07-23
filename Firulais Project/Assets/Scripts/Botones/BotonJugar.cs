using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonJugar : MonoBehaviour
{
    public void Jugador()
    {
        if (DATOS.personaje == null)
        {
            Defecto();
        }
        SceneManager.LoadScene("NombreJugador");
    }
    void Defecto()
    {
        DATOS.personaje = (GameObject)Resources.Load("Prefabs/Arturito", typeof(GameObject));
        DATOS.puntuacion = 500;
        DATOS.vidas = 3;
    }
}