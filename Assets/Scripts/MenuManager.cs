﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnLevelClickButton(int ind)
    {
        GlobalVars.CurrentLevel = ind;
        SceneManager.LoadScene(1);
    }
}
