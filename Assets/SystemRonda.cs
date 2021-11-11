using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemRonda : MonoBehaviour{

    public float speed;
    public float moveTime;
    private bool dirRight = true;
    private float timer;

    public int energia;
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

            if(energia <= 0){
            Invoke("DestroyBody", .5f);
        }

    }

        public void TakeDamage(int damage){
        energia -= damage;
    }
    
    private void DestroyBody(){
        Destroy(gameObject);
    }
}
