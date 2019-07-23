using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotonNombreJug : MonoBehaviour
{
    [SerializeField]
    private Text name;

    public void EmpezarJuego()
    {
        if (name.text.Equals(""))
        {
            DATOS.jugador = "Unknown";
        }
        else
        {
            DATOS.jugador = name.text;
        }      
        SceneManager.LoadScene("scene1");
    }
}
