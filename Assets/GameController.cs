using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{

        public GameObject gameOver;
        public bool end = false;

        public static GameController instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void ShowGameOver(){
        gameOver.SetActive(true);
    }

    public void ShowGameOver(bool end){
        this.end = end;
        gameOver.SetActive(true);
    }

    public void HideGameOver(){
        gameOver.SetActive(false);
    }

    public void RestartGame(){
        
        if(end){
            SceneManager.LoadScene("Title Scene", LoadSceneMode.Single);
        } else {
            SceneManager.LoadScene("LVL_1", LoadSceneMode.Single);
        }

        HideGameOver();

        Debug.Log(" recarregar pagina");
    }
}
