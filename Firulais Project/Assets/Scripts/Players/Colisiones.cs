using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Colisiones : MonoBehaviour
{
    private GameObject spawner;
    private GameObject vidas;
    Animator anim;
    private bool tierra;
    private bool hit = true;


    void Start ()
    {
        spawner = GameObject.Find("Spawn");
        vidas = GameObject.Find("Vida");
        anim = GetComponent<Animator>();

        Physics2D.IgnoreLayerCollision(9,8);
    }

	private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.collider.gameObject.tag.Equals("Agua")&& tierra)
		{
            if (SceneManager.GetActiveScene().name.Equals("scene1"))
            {
                tierra = false;
                spawner.GetComponent<SpawnPersonaje>().reSpawn();
            }
            else
            {
                if (DATOS.vidas > 1)
                {
                    tierra = false;
                    spawner.GetComponent<SpawnPersonaje>().reSpawn();
                    DATOS.vidas--;                   
                    vidas.GetComponent<Vidas>().actVidas();
                    DATOS.puntuacion -= 100;
                }
                else
                {
                    Destroy(this.gameObject);
                    SceneManager.LoadScene("GAME OVER");
                }
            }          
        }

        if (collision.collider.gameObject.tag.Equals("Suelo"))
        {        
            tierra = true;
        }       

        if (collision.collider.gameObject.tag.Equals("Enemy")&& hit)
        {
            hit = false;
            if (DATOS.vidas > 1)
            {
                DATOS.puntuacion -= 100;
                anim.SetTrigger("Muere");
                StartCoroutine(Muere(1));
            }
            else
            {
                DATOS.puntuacion -= 100;
                anim.SetTrigger("Muere");
                StartCoroutine(Muere(1));
                Destroy(gameObject);
                SceneManager.LoadScene("GAME OVER");
            }       
        }

        if (collision.gameObject.tag.Equals("Pocion"))
        {
            transform.localScale = transform.localScale * 1.2f;
            Destroy(collision.gameObject);
            GetComponent<MovePlayer>().jump = 4;
            StartCoroutine(recogeObjeto(0.2f));
        }
    }

    IEnumerator Muere(float time)
    {
        yield return new WaitForSeconds(time);

        anim.SetBool("Walk", false);
        anim.SetBool("Idle", true);
        anim.ResetTrigger("Muere");
        hit = true;

        spawner.GetComponent<SpawnPersonaje>().reSpawn();
        DATOS.vidas--;
        vidas.GetComponent<Vidas>().actVidas();
    }

    IEnumerator recogeObjeto(float time)
    {
        yield return new WaitForSeconds(time);
        transform.localScale = transform.localScale / 1.2f;
    }
}