using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxComponent : MonoBehaviour
{

    public LayerMask playerLayer;
    public AudioSource audioSource;

    // void Update(){
    //     RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.forward, 3, playerLayer);

    //     if(hitInfo.collider != null) {
    //         if(hitInfo.collider.CompareTag("Player")){
    //             TakeDamage();
    //         }
    //     }

    // }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var MACHINE = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerMachine>();
            MACHINE.PlayAudioBoom();
            TakeDamage();
        }
    }

    public void TakeDamage(){
        Debug.Log("Chamou");

        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Inimigo")){
            obj.GetComponent<EnemyFollow>().DestroyBody();
            Debug.Log("Inimigo");
        }

        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("InimigoPatrulha")){
            obj.GetComponent<SystemRonda>().DestroyBody();
            Debug.Log("Patrulha");
        }

        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("InimigoWall")){
            obj.GetComponent<Enemyshot>().DestroyBody();
            Debug.Log("Wall");
        }

        DestroyBody();
    }

    public void DestroyBody(){
        Destroy(gameObject);
    }

}
