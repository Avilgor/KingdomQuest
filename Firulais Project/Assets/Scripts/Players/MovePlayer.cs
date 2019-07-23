using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
	[SerializeField]
	public float movement;
	[SerializeField]
	public float jump;
    private bool grounded;
    Animator anim;


    void Start ()
    {
		anim = GetComponent<Animator>();     
    }


	void Update ()
    {
		Mov ();

    }

	public void Mov()
    {
        //Debug.Log("Se Mueve");
        if (grounded)
        { anim.SetBool("Salta", false); }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                anim.SetBool("Salta", true);
                GetComponent<Rigidbody2D>().AddForce(transform.up * jump * 100);
                grounded = false;
                Physics2D.IgnoreLayerCollision(9, 11, true);
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Physics2D.IgnoreLayerCollision(9, 11, false);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {             
            Physics2D.IgnoreLayerCollision(9, 11, true);           
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            Physics2D.IgnoreLayerCollision(9, 11, false);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Atk",true);
        }

        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            anim.SetBool("Walk", true);
            transform.Translate(Vector3.right * movement * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            anim.SetBool("Walk", true);
            transform.Translate(Vector3.right * movement * Time.deltaTime);          
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.A))
            {                   
            }
            else { anim.SetBool("Walk", false); }                
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.D))
            {                   
            }
            else { anim.SetBool("Walk", false); }              
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            anim.SetBool("Atk",false);
        }          
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag.Equals("Suelo"))
		{
            //Debug.Log("Toca suelo");			
            grounded = true;
		}

        if (collision.gameObject.tag.Equals("Climb"))
        {
            transform.Translate(Vector3.up * (movement+2.5f) * Time.deltaTime);
        }       
    }
}