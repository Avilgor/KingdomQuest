using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dispararfuego : MonoBehaviour {

	Transform Player;
	Transform objetivo;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindWithTag("Player").transform;
		//Debug.Log(Player.position);
	}
	
	// Update is called once per frame
	void Update () {
		objetivo=Player;
		transform.position = Vector2.MoveTowards(transform.position,objetivo.position,Time.deltaTime*5);
		//Debug.Log(objetivo.position);
		/*objetivo.position = Player.position;
		Debug.Log(Player.position);
		*/
	}
}