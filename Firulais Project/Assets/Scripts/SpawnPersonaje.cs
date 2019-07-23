using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPersonaje : MonoBehaviour
{
    private GameObject person = DATOS.personaje;
    static GameObject character;
 
    void Start()
    {
       character = Instantiate(person, transform.position, transform.rotation);
    }

    public  void reSpawn()
    {
        character.transform.position= new Vector3(transform.position.x, transform.position.y);
    }
}