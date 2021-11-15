using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectgun : MonoBehaviour
{

    public int dano;
    public float tempoDeVida;
    public float distancia;
    public LayerMask layerInimigo;
    // Start is called before the first frame update
    void Start()
    {
        // Invoke("DestruirProjetil", tempoDeVida);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.forward, distancia, layerInimigo);

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
