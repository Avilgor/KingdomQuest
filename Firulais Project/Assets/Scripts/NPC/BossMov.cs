using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossMov : MonoBehaviour
{

    [SerializeField]
    public Transform[] puntos;
    [SerializeField]
    public float velocidad;
    Animator anim;
    int salud = 3;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Walk", true);
    }

    void Update()
    {
        if (anim.GetBool("Walk"))
        {
            transform.Translate(Vector3.right * velocidad * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Objetivo"))
        {
            if (collision.gameObject.name == "BossA")
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            if (collision.gameObject.name == "BossB")
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }


        if (collision.collider.gameObject.tag.Equals("Player"))
        {
            anim.SetBool("Walk", false);
            anim.SetTrigger("Atk");
            StartCoroutine(doAtk(1));
        }


        if (collision.collider.gameObject.tag.Equals("Attack"))
        {
            Destroy(collision.gameObject);
            if (salud > 1)
            {
                salud--;
                anim.SetBool("Walk", false);
                anim.SetTrigger("Hurt");
                StartCoroutine(gotHit(0.5f));
            }
            else
            {
                anim.SetBool("Walk", false);
                anim.SetTrigger("Die");
                StartCoroutine(Muere(1));
            }
        }
    }


    IEnumerator gotHit(float time)
    {
        yield return new WaitForSeconds(time);
        transform.localScale = transform.localScale / 1f;
        anim.SetBool("Walk", true);
    }

    IEnumerator doAtk(float time)
    {
        yield return new WaitForSeconds(time);
        transform.localScale = transform.localScale / 1f;
        anim.SetBool("Walk", true);
    }

    IEnumerator Muere(float time)
    {
        yield return new WaitForSeconds(time);
        DATOS.puntuacion += 500;
        Destroy(gameObject);
        SceneManager.LoadScene("Victory");
    }
}