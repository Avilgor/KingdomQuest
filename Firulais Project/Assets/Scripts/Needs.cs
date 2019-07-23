using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needs : MonoBehaviour
{
    void Start()
    {
        DATOS.Ranking = RankingControl.doList();
    }
}