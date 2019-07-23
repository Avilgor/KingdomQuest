using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinchos : MonoBehaviour
{
    bool derecha = true;
	
	void Update ()
    {
        if (derecha)
        {
            transform.Translate(Vector3.left * 3 * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * 3 * Time.deltaTime);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("ObjDerecha"))
        {
            derecha = false;
        }

        if (collision.gameObject.tag.Equals("ObjIzquierda"))
        {
            derecha = true;
        }
    }
}