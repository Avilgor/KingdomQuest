using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnUbbe : MonoBehaviour
{
    public void seleccionar()
    {
        DATOS.personaje = (GameObject)Resources.Load("prefabs/Ubbe", typeof(GameObject));
        DATOS.puntuacion = 500;
        DATOS.vidas = 4;
        SceneManager.LoadScene("Menu");
    }
}