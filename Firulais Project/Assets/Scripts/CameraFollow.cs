using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private float smoothTime = .15f;

    [SerializeField]
    public float MaxX, MinX, MaxY, MinY;
    private Transform Objetivo;

    private Vector3 pos = new Vector3();
    Vector3 velocidad = Vector3.zero;

    void Start ()
    {
        Objetivo = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	void FixedUpdate ()
    {
        try
        {
            pos = Objetivo.position;
        }
        catch (Exception e) { }


        if (pos == null)
        {
        }
        else
        {
            pos.y = Mathf.Clamp(Objetivo.position.y, MinY, MaxY);
            pos.x = Mathf.Clamp(Objetivo.position.x, MinX, MaxX);
            pos.z = transform.position.z;
            transform.position = Vector3.SmoothDamp(transform.position, pos,ref velocidad, smoothTime);
        }
    }
}