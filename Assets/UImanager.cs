using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public Text Score;
    void Start()
    {
        if (PlayerPrefs.GetInt("score") == 0)
        {
            PlayerPrefs.SetInt("score", 500);
        }
        Score.text = PlayerPrefs.GetInt("score").ToString();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    
    void Update()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
