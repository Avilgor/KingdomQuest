using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisionPinchos : MonoBehaviour {

	[SerializeField]
	private GameObject pinchos;
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision){

	if (collision.gameObject.tag.Equals("Agua"))
		{
		Destroy(this.gameObject); 
        }
	if (collision.gameObject.tag.Equals("Suelo"))
		{
		Destroy(this.gameObject);
        }
	if (collision.gameObject.tag.Equals("Enemy"))
		{
		Destroy(collision.gameObject);
        }
	}
}