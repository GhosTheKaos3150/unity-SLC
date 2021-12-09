using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerMachine : MonoBehaviour
{

    public AudioSource audioSource;
    public int wave = 1;
    private int[] wave1 = {10, 5, 0};
    private int[] wave2 = {10, 15, 0};
    private int[] wave3 = {10, 10, 5};

    private int baseEnemyEnergy = 6;
    private int baseEnemyATK = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayAudioBoom(){
        audioSource.PlayOneShot(audioSource.clip, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
