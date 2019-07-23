using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class cuadradoPlatformseDestruye : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")            
        {
            Invoke("eseprar", 0.15f);         
        }
    }

    public void eseprar()
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
        Invoke("Volver", 5f);
    }

    public void Volver()
    {
        gameObject.SetActive(true);
    }
}