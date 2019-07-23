using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vidas : MonoBehaviour
{
    [SerializeField]
    private Text vida;
    int vidas = DATOS.vidas;

    void Start()
    {
        vida.text = "Vidas: " + vidas;
    }

    public void actVidas()
    {
        vidas--;
        vida.text = "Vidas: " + vidas;       
    }
}