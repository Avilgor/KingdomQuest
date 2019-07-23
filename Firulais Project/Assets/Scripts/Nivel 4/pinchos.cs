using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinchos : MonoBehaviour {

	private Rigidbody2D rb;
	bool der=true;
	// Use this for initialization
	void Start () {
		//transform.Translate(Vector3.down * 3 * Time.deltaTime);
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(der==true){
			transform.Translate(Vector3.up * 3 * Time.deltaTime);
		}else{
		transform.Translate(Vector3.down * 3 * Time.deltaTime);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.name == "izquierda"){
			der=true;
		}
		if(collision.gameObject.name == "derecha"){
			der=false; 
		}
	}
}