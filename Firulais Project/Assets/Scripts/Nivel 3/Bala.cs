using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {

    private Rigidbody2D enemigo;
    public float velocidad = 2f;


    // Use this for initialization
    void Start () {
        enemigo = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.down * velocidad * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
