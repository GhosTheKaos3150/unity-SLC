using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{

    private int switchText = 0;
    public Text pressStart;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
        } else if (Input.anyKey){
            SceneManager.LoadScene("LVL_1", LoadSceneMode.Single);
        }
    }
}
