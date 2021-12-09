using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{

    // Vida
    private int health;
    public Text healthText;

    // Energia
    private int xp;
    public Text xpText;
    public Text waveText;
    public GameObject MACHINE;

    void Start(){
        var control = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        health = control.energia;
        xp = control.atp;

        // Update das legendas
        healthText.text = "Energia: " + health.ToString();
        healthText.SetAllDirty();

        
        xpText.text = "ATP: " + xp.ToString();
        xpText.SetAllDirty();

        waveText.text = "WAVE" + MACHINE.GetComponent<GameControllerMachine>().wave.ToString();
        waveText.SetAllDirty();
    }

    // Update is called once per frame
    void Update(){
        var control = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        health = control.energia;
        xp = control.atp;

        healthText.text = "Energia: " + health.ToString();
        healthText.SetAllDirty();

        xpText.text = "ATP: " + xp.ToString();
        xpText.SetAllDirty();

        waveText.text = "WAVE " + MACHINE.GetComponent<GameControllerMachine>().wave.ToString();
        waveText.SetAllDirty();
    }

    public void UpdateLifeBy(int life){
        health = life; 
    }

}
