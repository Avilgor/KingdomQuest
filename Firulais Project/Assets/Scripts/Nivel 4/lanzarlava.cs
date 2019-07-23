using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanzarlava : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.up*2*Time.deltaTime);
	}
}