using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour {

    public GameObject prefabBala;
    public float tiempoGenera = 1.75f;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Genera", 0f, tiempoGenera);
    }
	
	// Update is called once per frame
	void Update () {
    }

    void Genera()
    {
        Instantiate(prefabBala, transform.position, Quaternion.identity);
    }
}