using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public AudioSource audioSource;
    public float volume = 0.5f;

    public float runSpeed = 40f;
    public float hMove = 0f;
    public bool jump = false;
    public bool crouch = false;

    // Params
    public int energia = 6;
    public int atp = 0;
    public int nv = 1;

    // Axis
    public int mnemonicAxis = 1;

    private bool estaAtirando = false;
    private float tempoUltimoTiro;

    public Transform tiroverde; // local onde o tiro sai

    public GameObject projetilPrefab; // prefabricado do tiro

    public float velocidadeProjetil;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        updateLevel();

        Atirar();
        hMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        // animator.SetFloat("speed", Mathf.Abs(hMove)); // desativei por enquanto porque começou a dar erro e não sei o que aconteceu 

        // if (Input.GetButtonDown("w"))
        if (Input.GetAxis("Horizontal") < 0f) mnemonicAxis = -1;
        // if (Input.GetButtonDown("s"))
        if (Input.GetAxis("Horizontal") > 0f) mnemonicAxis = 1;

        switch (mnemonicAxis){
            case 1:
                spriteRenderer.flipX = false;
                break;
            case -1:
                spriteRenderer.flipX = true;
                break;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

    }

    void FixedUpdate()
    {
        controller.Move(hMove * Time.fixedDeltaTime, crouch, jump);
        animator.SetFloat("speed", Mathf.Abs(hMove));
        jump = false;
    }

    void updateLevel(){
        if(atp>= 50){
            nv++;
            energia += 5;
            atp -= 50;
        };
    }

    void Atirar()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(audioSource.clip, volume);
            Debug.Log(" ta atirando verde");
            Transform shotPoint = tiroverde;

            GameObject projectile = Instantiate(projetilPrefab, shotPoint.position, transform.rotation);

            // estaAtirando = true;
            tempoUltimoTiro = .7f;

            // projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadeProjetil, 0);


            if (mnemonicAxis == 1)
            {
                projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadeProjetil, 0);
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            } else if (mnemonicAxis == -1) {
                projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidadeProjetil, 0);
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
        }


        tempoUltimoTiro -= Time.deltaTime;
        if (tempoUltimoTiro <= 0)
        {
            estaAtirando = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Inimigo" || collision.gameObject.tag == "InimigoPatrulha"){
            Debug.Log(energia);
            // Debug.Log("tocou no player");
            energia--;
            Debug.Log(energia);
            if(energia <=0){
                Destroy(GameObject.FindGameObjectWithTag("Player"));
                GameController.instance.ShowGameOver();
            }
        }
    }

    
    public void TakeDamage(int damage){
        energia -= damage;
    }
}
