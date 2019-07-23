using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnAtras : MonoBehaviour
{

    public void Volver()
    {
        SceneManager.LoadScene("Menu");
    }
}