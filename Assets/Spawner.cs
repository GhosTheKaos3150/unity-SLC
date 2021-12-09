using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPatrol;
    public GameObject enemyFollow;
    public GameObject enemyWall;
    public GameObject antibiotico;
    public float spawnRate;
    private float nextSpawn = 0f;
    // Update is called once per frame
    
    public void SpawnPatrol(){
        Instantiate(enemyPatrol, transform.position, enemyPatrol.transform.rotation);
    }

    public void SpawnFollow(){
        Instantiate(enemyFollow, transform.position, enemyFollow.transform.rotation);
    }

    public void SpawnWall(){
        Instantiate(enemyWall, transform.position, enemyWall.transform.rotation);
    }

    public void SpawnANT(){
        Instantiate(antibiotico, transform.position, antibiotico.transform.rotation);
    }

}
