using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonSalir : MonoBehaviour
{
    public void cerrarAPP()
    {
        ConnectServer connection = new ConnectServer();
        connection.CloseServer();
        Application.Quit();
    }
}