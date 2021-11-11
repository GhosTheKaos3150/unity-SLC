using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float Speed;

    public float distancia;

    public int energia;
    private Transform Target;
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, Target.position) > distancia){
        transform.position = Vector2.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
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
