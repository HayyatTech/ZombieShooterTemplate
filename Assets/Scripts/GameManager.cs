using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PlayerWeapons playerWeapons;
    public GameObject WinPanel;
    public GameObject PlayerControls;
    public Text Levelno,Objective,rewardText; 
    private int Score;
    public static int Kills;
    public static GameManager instance;
    private Level CurrentLevel;
    public GameObject[] Levels;
    void Start()
    {
        if (instance == null)
            instance = this;

        Init();
    }

    private void Init()
    {
        for (int i = 0; i < Levels.Length; i++)
        {
            if (GlobalVars.CurrentLevel - 1 == i)
            {
                Levels[i].SetActive(true);
                CurrentLevel = Levels[i].GetComponent<Level>();
            }
        }
        Kills = 0;
        Objective.text = "Zombies " + Kills + "/" + CurrentLevel.SpawnedZombies;
        Levelno.text = "Level " + GlobalVars.CurrentLevel;
        Score = PlayerPrefs.GetInt("score");
    }
    public void CheckLevelProgress()
    {
        if (Kills == CurrentLevel.SpawnedZombies)
        {
           OnCompleteLevel();
        }
        instance.Objective.text = "Zombies " + Kills + "/" + CurrentLevel.SpawnedZombies;
    }

    public void OnCompleteLevel()
    {
        instance.PlayerControls.SetActive(false);
        instance.WinPanel.SetActive(true);
        instance.rewardText.text = "Reward " + CurrentLevel.Reward;
        instance.Score += CurrentLevel.Reward;
        PlayerPrefs.SetInt("score",instance.Score);
    }

    public void Home()
    {
        
        SceneManager.LoadScene(0);
    }
    public void NextLevel()
    {
        GlobalVars.CurrentLevel++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddAmmo()
    {
        for(int i = 0; i < playerWeapons.weaponOrder.Length; i++)
        {
            if (playerWeapons.weaponOrder[i].gameObject.activeSelf)
            {
                playerWeapons.weaponOrder[i].GetComponent<WeaponBehavior>().ammo += 30;
            }
        }
    }
}
