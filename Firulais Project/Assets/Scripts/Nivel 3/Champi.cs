using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Champi : MonoBehaviour
{
    [SerializeField]
    public float velocidad = 2f;
    private Rigidbody2D enemigo;

    // Use this for initialization
    void Start()
    {
        enemigo = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(10, 11);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * velocidad * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Pinchos"))
        { Destroy(gameObject); }

        if (collision.gameObject.tag.Equals("Player"))
        { Destroy(gameObject); }

        if (collision.gameObject.tag.Equals("Attack"))
        { Destroy(gameObject); }
    }
}