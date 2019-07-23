using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarFuego : MonoBehaviour
{
    GameObject bola;
    Transform boca;
    private float tempo=2;
    void Start ()
    {
        bola = (GameObject)Resources.Load("prefabs/BolaFuego", typeof(GameObject));
        boca = gameObject.transform.GetChild(0);
    }
	
	void Update ()
    {
        tempo += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.P) && tempo>2)
        {
            GameObject Fogonazo = Instantiate(bola, boca.transform.position, boca.transform.rotation);
            tempo = 0;
        }
    }
}