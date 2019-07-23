using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generarfuego : MonoBehaviour {

	[SerializeField]
	GameObject fuego;
	[SerializeField]
	GameObject dragon;

	// Use this for initialization
	void Start () {
		InvokeRepeating("Genera",2f,2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void Genera(){
		Instantiate(fuego, dragon.transform.position, dragon.transform.rotation);
	}
}