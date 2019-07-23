using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAmmo : MonoBehaviour
{
    float tempo = 0;
    void Update()
    {
        tempo += Time.deltaTime;
        transform.Translate(Vector3.left * 3 * Time.deltaTime);
        if (tempo > 2)
        {
            Destroy(gameObject);
        }
    }
}