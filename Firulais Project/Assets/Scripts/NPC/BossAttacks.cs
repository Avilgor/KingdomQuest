using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    GameObject ATK,skillShot;
    float tempo = 0;
    int skill; 
	

	void Update ()
    {
        tempo += Time.deltaTime;

        if (tempo > 3)
        {
            tempo = 0;
            skill = Random.Range(0, 3);
            switch (skill)
            {
                case 0:
                    ATK = (GameObject)Resources.Load("prefabs/Spark", typeof(GameObject));
                    break;
                case 1:
                    ATK = (GameObject)Resources.Load("prefabs/FireSpin", typeof(GameObject));
                    break;
                case 2:
                    ATK = (GameObject)Resources.Load("prefabs/BlackRing", typeof(GameObject));
                    break;
            }
            skillShot = Instantiate(ATK, transform.position, transform.rotation);
        }
	}
}