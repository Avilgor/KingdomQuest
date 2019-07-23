using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntuacion : MonoBehaviour
{

	[SerializeField]
	private Text puntuacion;
	float tempo=0;

	void Start ()
    {
		puntuacion.text = "Puntuacion: "+DATOS.puntuacion;
	}
	

	void Update ()
    {
		tempo += Time.deltaTime;
		contarPuntos ();
	}

	public void contarPuntos()
	{      
        if (tempo > 1 && DATOS.puntuacion > 0) 
		{
            DATOS.puntuacion--;
			tempo = 0;
			puntuacion.text = "Puntuacion: "+ DATOS.puntuacion;
		}
    }
}