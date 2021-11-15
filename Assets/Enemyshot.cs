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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Atirar();
    }


            void Atirar(){
        if (Input.GetMouseButtonDown(1)){
            Debug.Log(" ta atirando no player 2");
            Transform shotPoint = tiroazul;
            
            GameObject projectile = Instantiate(projetilPrefab, shotPoint.position, transform.rotation);

            // estaAtirando = true;
            tempoUltimoTiro = .7f;

            // projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadeProjetil, 0);


        if(Input.GetAxis("Horizontal") > 0f || Input.GetAxis("Horizontal") == 0f){
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadeProjetil, 0);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if(Input.GetAxis("Horizontal") < 0f || Input.GetAxis("Horizontal") == 0f){
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidadeProjetil, 0);
        }
        
        }


        tempoUltimoTiro -= Time.deltaTime;
        if(tempoUltimoTiro <= 0 ){
            estaAtirando = true;
        }
    }
}
