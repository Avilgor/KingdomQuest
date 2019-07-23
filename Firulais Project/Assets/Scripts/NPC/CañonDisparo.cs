using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CañonDisparo : MonoBehaviour
{
    public GameObject Ammo;
    public float time = 1.75f;

    void Start ()
    {
        InvokeRepeating("Shoot", 0f, time);
    }

    void Shoot()
    {
        Instantiate(Ammo, transform.position, Quaternion.identity);
    }
}