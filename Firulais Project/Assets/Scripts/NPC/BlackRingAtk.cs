using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackRingAtk : MonoBehaviour
{
    float tam = 1.03f;
    float tempo = 0;
	
	void Update ()
    {
        tempo += Time.deltaTime;
        transform.localScale = transform.localScale * tam;
        if (tempo > 1)
        {
            Destroy(gameObject);
        }
    }
}