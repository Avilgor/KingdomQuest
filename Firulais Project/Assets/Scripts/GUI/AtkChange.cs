using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkChange : MonoBehaviour
{
    Animator anim;
	void Start ()
    {
        anim = GetComponent<Animator>();
    }

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            anim.SetBool("AtkUp", false);
            StartCoroutine(Available(2));
        }      
    }

    IEnumerator Available(float time)
    {
        yield return new WaitForSeconds(time);
        anim.SetBool("AtkUp", true);
    }
}