using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerMachine : MonoBehaviour
{

    public AudioSource audioSource;
    public int wave = 0;
    private int[] waves = {5, 10, 15};
    private GameObject[] spawns;
    private int spawnLen;
    private float timer;

    private int baseEnemyEnergy = 6;
    private int baseEnemyATK = 1;

    public GameObject gameOver;

    public static GameControllerMachine instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        spawns = GameObject.FindGameObjectsWithTag("Spawner");
        spawnLen = spawns.Length;
    }

    public void ShowGameOver(){
        gameOver.SetActive(true);
    }

    public void RestartGame(){
        SceneManager.LoadScene("Title Scene", LoadSceneMode.Single);
    }

    public void PlayAudioBoom(){
        audioSource.PlayOneShot(audioSource.clip, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }

    void Spawn(){
        var rand = Random.Range(0, spawnLen);
        var which = Random.Range(0, 4);

        var spawn = spawns[rand];

        timer += Time.deltaTime;

        if (timer >= 2f){
            if(waves[wave] > 0){

                switch(which){
                    case 0:
                        spawn.GetComponent<Spawner>().SpawnFollow();
                        waves[wave]--;
                        break;
                    case 1:
                        spawn.GetComponent<Spawner>().SpawnPatrol();
                        waves[wave]--;
                        break;
                    case 2:
                        spawn.GetComponent<Spawner>().SpawnWall();
                        waves[wave]--;
                        break;
                    case 3:
                        spawn.GetComponent<Spawner>().SpawnANT();
                    break;
                }

            } else if (GameObject.FindGameObjectsWithTag("Inimigo").Length == 0 && GameObject.FindGameObjectsWithTag("InimigoPatrulha").Length == 0 && 
            GameObject.FindGameObjectsWithTag("InimigoWall").Length == 0){
                if(wave >= waves.Length){
                    SceneManager.LoadScene("Title Scene", LoadSceneMode.Single);
                } else {
                    wave++;
                }
            }

            timer = 0f;
        }

        
    }
}
