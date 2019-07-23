using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnFolagon : MonoBehaviour {

    public void seleccionar()
    {
        DATOS.personaje = (GameObject)Resources.Load("prefabs/Folagon", typeof(GameObject));
        DATOS.puntuacion = 500;
        DATOS.vidas = 2;
        SceneManager.LoadScene("Menu");
    }
}