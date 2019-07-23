using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generarlava : MonoBehaviour {

	[SerializeField]
	GameObject fuego;
	/*[SerializeField]
	GameObject generador;*/
	[SerializeField]
	float empieza=0f;
	// Use this for initialization
	void Start () {
		InvokeRepeating("Genera",empieza,3f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Genera(){
		Instantiate(fuego, transform.position, Quaternion.identity);
	}
}