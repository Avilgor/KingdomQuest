using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBolaFuego : MonoBehaviour
{
    private float duracion;
    void Start()
    {
        Physics2D.IgnoreLayerCollision(10, 8);
    }

    void Update()
    {
        duracion += Time.deltaTime;
        if (duracion > 2)
        {
            Destroy(this.gameObject);
            duracion = 0;
        }
        else
        {
            transform.Translate(Vector3.right * 3 * Time.deltaTime);
        }    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Suelo"))
        {
            Destroy(this.gameObject);
        }
    }
}