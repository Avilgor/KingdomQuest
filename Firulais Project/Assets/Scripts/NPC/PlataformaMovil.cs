using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
	bool subir=true;	
	void Update ()
    {	
		if(subir)
        {
			transform.Translate(Vector3.up*1.5f*Time.deltaTime);	
		}else
        {
			transform.Translate(Vector3.down*1.5f*Time.deltaTime);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.tag.Equals("Techo"))
		{
			subir=false;
		}
		if (collision.gameObject.tag.Equals("Suelo"))
		{
			subir=true;
		}
	}
}