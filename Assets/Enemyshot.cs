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

    void Update()
    {
        Atirar();
    }


    void Atirar(){
        if (Input.GetMouseButtonDown(1)){
        // Debug.Log(" inimigo atirando");
        Transform shotPoint = tiroazul;

        GameObject projectgun = Instantiate(projetilPrefab, shotPoint.position, transform.rotation);

        // estaAtirando = true;
        tempoUltimoTiro = .7f;

        projectgun.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadeProjetil, 0);
    }

        tempoUltimoTiro -= Time.deltaTime;
        if(tempoUltimoTiro <= 0 ){
            estaAtirando = true;
        }
    }
}
