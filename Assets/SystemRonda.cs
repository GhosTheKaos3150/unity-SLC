using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemRonda : MonoBehaviour{

    public float speed;
    public float moveTime;
    private bool dirRight = true;
    private float timer;
    public Animator animator;
    public BoxCollider2D normalCollider;
    public BoxCollider2D deadCollider;

    public int energia;
    private int ATP = 10;
    // Update is called once per frame
    void Update(){
        if(dirRight){
            transform.Translate(Vector2.right*speed * Time.deltaTime);
        }else{
            transform.Translate(Vector2.left*speed * Time.deltaTime);
        }
        timer += Time.deltaTime;
        if(timer >= moveTime){
            dirRight = !dirRight;
            timer = 0f;
        }

        var spriteRederer = GetComponent<SpriteRenderer>();
        if (dirRight) {
            spriteRederer.flipX = false;
        } else {
            spriteRederer.flipX = true;
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
