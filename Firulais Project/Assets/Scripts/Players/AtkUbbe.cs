using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkUbbe : MonoBehaviour
{

    GameObject corte;
    Transform espada;
    private float tempo=2;
    void Start()
    {
        corte = (GameObject)Resources.Load("prefabs/EspadaUbbe", typeof(GameObject));
        espada = gameObject.transform.GetChild(0);
    }

    void Update()
    {
        tempo += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.P) && tempo > 2)
        {
            GameObject tajo = Instantiate(corte, espada.transform.position, espada.transform.rotation);
            tempo = 0;
        }
    }
}