using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MostrarNivel : MonoBehaviour
{
    [SerializeField]
    private Text nivel;
    void Start ()
    {
        nivel.text = SceneManager.GetActiveScene().name;
    }
}