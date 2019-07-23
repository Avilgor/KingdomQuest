using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkAtk : MonoBehaviour
{
    float tempo = 0;
    Vector3 target;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform.position;
    }

    void Update()
    {
        tempo += Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, 0.07f);

        if (tempo > 2)
        {
            Destroy(gameObject);
        }
    }
}