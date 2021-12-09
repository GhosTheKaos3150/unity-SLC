using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectgun : MonoBehaviour
{

    public int dano;

    public float Speed;
    public float tempoDeVida;
    public float distancia;

    public float alvo;
    public LayerMask layerInimigo;

    private Vector3 Target;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        Invoke("DestruirProjetil", tempoDeVida);
    }

    // Update is called once per frame
    void Update()
    {

        if(Vector2.Distance(transform.position, Target) > alvo){
            transform.position = Vector2.MoveTowards(transform.position, Target, Speed * Time.deltaTime);
        }
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.forward, distancia, layerInimigo);

        if (transform.position == Target){
            Invoke("DestruirProjetil", 0f);
        }

        if(hitInfo.collider != null){
            if(hitInfo.collider.CompareTag("Inimigo")){
                Debug.Log(" ta acertando o player");
                // hitInfo.collider.GetComponent<EnemyFollow>().TakeDamage(dano);
                // hitInfo.collider.GetComponent<SystemRonda>().TakeDamage(dano);
            }
            DestruirProjetil();
        }
    }

    void DestruirProjetil(){
        Destroy(gameObject);
    }
}
