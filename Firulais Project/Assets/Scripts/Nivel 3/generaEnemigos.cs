using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generaEnemigos : MonoBehaviour
{

    public GameObject prefabEnemigo;
    public float tiempoGenera = 1.75f;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Genera", 0f, tiempoGenera); //metodo, primera invocacion, cada cuanto.
        Physics2D.IgnoreLayerCollision(11, 10);
    }

    // Update is called once per frame
    void Update()
    {
    }
    void Genera()
    {
        Instantiate(prefabEnemigo, transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Attack"))
        {
            Destroy(gameObject);
        }
    }
}