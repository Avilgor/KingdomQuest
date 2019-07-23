using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonPersonajes : MonoBehaviour
{
    //AudioSource audioSource;
    public void Personajes()
    {           
        SceneManager.LoadScene("SelecPersonaje");
    }
   /* public void clickSound()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.Play();
    }*/
}