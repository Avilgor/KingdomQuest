using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkFirulais : MonoBehaviour
{
    GameObject atk;
    Transform garras;
    private float tempo=2;
    void Start()
    {
        atk = (GameObject)Resources.Load("prefabs/GarrasFirulais", typeof(GameObject));
        garras = gameObject.transform.GetChild(0);
    }
    void Update()
    {
        tempo += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.P) && tempo > 2)
        {
            GameObject tajo = Instantiate(atk, garras.transform.position, garras.transform.rotation);
            tempo = 0;
        }
    }
}