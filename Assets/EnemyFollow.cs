using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float Speed;
    public float distancia;
    public int energia;
    private int ATP = 15;
    public Animator animator;
    private Transform Target;
    public BoxCollider2D normalCollider;
    public BoxCollider2D deadCollider;
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localEulerAngles.z%90 == 0){
            spriteRenderer.flipY = !spriteRenderer.flipY;
        }

        if(Vector2.Distance(transform.position, Target.position) > distancia){
            var value = Vector2.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
            transform.position = value;

            var spriteRederer = GetComponent<SpriteRenderer>();
            if (Target.position.x > value.x) {
                spriteRederer.flipX = false;
            }  
            if (Target.position.x < value.x) {
                spriteRederer.flipX = true;
            }
        }

        if(energia <= 0){
            Invoke("DestroyBody", .5f);
        }
    }

    public void TakeDamage(int damage){
        energia -= damage;
    }
    
    public void DestroyBody(){
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
