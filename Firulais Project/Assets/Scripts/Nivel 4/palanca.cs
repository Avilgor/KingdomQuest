using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class palanca : MonoBehaviour {

	bool ok=false;
	[SerializeField]
	private GameObject pinchos;

	private Rigidbody2D rb;

	void Start ()
    {
		
		rb = pinchos.GetComponent<Rigidbody2D> ();
	}
	

	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag.Equals("Player"))
        {
            try
            {
                transform.rotation = Quaternion.Euler(0, 0, 45);
                rb.AddForce(Physics.gravity * rb.mass * 50);
            } catch (Exception e)
            {

            }
			
		}
	}
}