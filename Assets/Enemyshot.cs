using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyshot : MonoBehaviour
{
    private bool estaAtirando = false;
    private float tempoUltimoTiro;

    public Transform tiroazul; // local onde o tiro sai

    public GameObject projetilPrefab; // prefabricado do tiro

    public float velocidadeProjetil;
    public int energia;
    private int ATP = 25;
    public Animator animator;
    public PolygonCollider2D normalCollider;
    public BoxCollider2D deadCollider;
    public AudioSource audioSource;

    public int energia;

    void Update()
    {
        Atirar();


        if (energia <= 0)
        {
            Invoke("DestroyBody", .5f);
        }
    }


    void Atirar(){
        if (!estaAtirando){
            audioSource.PlayOneShot(audioSource.clip, 1f);
            Transform shotPoint = tiroazul;

            GameObject projectgun = Instantiate(projetilPrefab, shotPoint.position, transform.rotation);

            estaAtirando = true;
            tempoUltimoTiro = .7f;

            projectgun.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadeProjetil, 0);
        }

        tempoUltimoTiro -= Time.deltaTime;
        if(tempoUltimoTiro <= 0 ){
            estaAtirando = false;
        }
    }

    public void TakeDamage(int damage)
    {
        energia -= damage;
    }

    public void DestroyBody()
    {
        if (!animator.GetBool("dead")){
            var player = GameObject.FindGameObjectWithTag("Player");
            var playerScript = player.GetComponent<PlayerScript>();
            playerScript.atp += ATP;
        }

        animator.SetBool("dead", true);
        normalCollider.enabled = false;
        deadCollider.enabled = true;
    }
}
