using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPatrol : MonoBehaviour
{
    [SerializeField]
    public float velocidad;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Walk", true);
    }

    void Update ()
    {
        if (anim.GetBool("Walk"))
        {
            transform.Translate(Vector3.left * velocidad * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("ObjDerecha"))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);         
        }

        if (collision.gameObject.tag.Equals("ObjIzquierda"))
        {
             transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (collision.gameObject.tag.Equals("Attack"))
        {
            Destroy(collision.gameObject);
            anim.SetBool("Walk", false);
            anim.SetTrigger("Die");
            //Debug.Log("Tocado");
            StartCoroutine(Muere(0.5f));
        }
    }

    IEnumerator Muere(float time)
    {
        yield return new WaitForSeconds(time);
        DATOS.puntuacion += 50;
        Destroy(gameObject);
    }
}