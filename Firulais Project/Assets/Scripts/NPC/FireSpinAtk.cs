using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpinAtk : MonoBehaviour
{
    private Vector3 zAxis = new Vector3(0, 0, 1);
    private float RotateSpeed = 10f;
    private float Radius = 1.8f;
    float tempo = 0;

    private Vector2 centre;
    private float angle;

    private void Start()
    {
        
    }

    private void Update()
    {
        tempo += Time.deltaTime;
        centre = GameObject.Find("Boss").transform.position;
        angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * Radius;
        transform.position = centre + offset;

        if (tempo > 2)
        {
            Destroy(gameObject);
        }
    }
}