using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMusic : MonoBehaviour
{
    void Awake()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("BackgroundMusic");
        if (obj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        //Debug.Log("No se destruye");
    }

    private void Start()
    {
        if (DATOS.BKMusic == false)
        {
            GetComponent<AudioSource>().Stop();
            //Debug.Log("Para");
        }
        else { GetComponent<AudioSource>().Play(); }
    }

    private void Update()
    {
        if (GetComponent<AudioSource>().isPlaying && DATOS.BKMusic==false)
        {
            GetComponent<AudioSource>().Stop();
        }

        if (GetComponent<AudioSource>().isPlaying==false && DATOS.BKMusic == true)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}