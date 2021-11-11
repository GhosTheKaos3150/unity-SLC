using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;
    float hMove = 0f;
    bool jump = false;
    bool crouch = false;

    private bool estaAtirando = false;
    private float tempoUltimoTiro;

    public Transform tiroverde; // local onde o tiro sai

    public GameObject projetilPrefab; // prefabricado do tiro

    public float velocidadeProjetil;

    // Update is called once per frame
    void Update()
    {

        Atirar();
        hMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        // animator.SetFloat("speed", Mathf.Abs(hMove)); // desativei por enquanto porque começou a dar erro e não sei o que aconteceu 

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

    }

    void FixedUpdate()
    {
        controller.Move(hMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }


        void Atirar(){
        if (Input.GetMouseButtonDown(0)){
            Debug.Log(" ta atirando");
            Transform shotPoint = tiroverde;
            
            GameObject projectile = Instantiate(projetilPrefab, shotPoint.position, transform.rotation);

            estaAtirando = true;
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
