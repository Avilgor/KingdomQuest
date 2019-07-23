using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEspada : MonoBehaviour
{
    private float duracion;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(9,8);
    }

    // Update is called once per frame
    void Update ()
    {
        duracion += Time.deltaTime;
        if (duracion > 0.4)
        {
            Destroy(this.gameObject);
            duracion = 0;
        }
    }
}