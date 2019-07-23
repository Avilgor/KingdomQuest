using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DevCharacter : MonoBehaviour
{
	void Update ()
    {
        if (Input.GetKey(KeyCode.F10))
        {
            DATOS.personaje = (GameObject)Resources.Load("prefabs/Arturito", typeof(GameObject));
            DATOS.puntuacion = 500000;
            DATOS.vidas = 500;
            SceneManager.LoadScene("Menu");
        }
	}
}
