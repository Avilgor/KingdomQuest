using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuegoDragon : MonoBehaviour {

    float tempo = 0;
    Vector3 target;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform.position;
    }

    void Update()
    {
        tempo += Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, 0.2f);

        if (tempo > 1)
        {
            Destroy(gameObject);
        }
    }
}