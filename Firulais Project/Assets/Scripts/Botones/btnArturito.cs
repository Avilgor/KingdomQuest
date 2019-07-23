using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnArturito : MonoBehaviour
{
    public void seleccionar()
    {
        DATOS.personaje = (GameObject)Resources.Load("prefabs/Arturito", typeof(GameObject));
        DATOS.puntuacion = 500;
        DATOS.vidas = 3;
        SceneManager.LoadScene("Menu");
    }
}