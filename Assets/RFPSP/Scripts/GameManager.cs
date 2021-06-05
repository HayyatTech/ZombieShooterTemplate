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
  
    void Start()
    {
        if (instance == null)
            instance = this;
        Kills = 0;
        Objective.text = "Zombies " + Kills + "/" + CurrentLevel.currentLevel.SpawnedZombies;
        Levelno.text ="Level "+ CurrentLevel.currentLevel.levelNo;
        Score = PlayerPrefs.GetInt("score");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void CheckLevelProgress()
    {
        if (Kills == CurrentLevel.currentLevel.SpawnedZombies)
        {
           OnCompleteLevel();
        }
        instance.Objective.text = "Zombies " + Kills + "/" + CurrentLevel.currentLevel.SpawnedZombies;
    }

    public static void OnCompleteLevel()
    {
        instance.PlayerControls.SetActive(false);
        instance.WinPanel.SetActive(true);
        instance.rewardText.text = "Reward " + CurrentLevel.currentLevel.Reward;
        instance.Score += CurrentLevel.currentLevel.Reward;
        PlayerPrefs.SetInt("score",instance.Score);
    }

    public void Home()
    {
        Destroy(CurrentLevel.currentLevel);
        SceneManager.LoadScene(0);
    }
    public void NextLevel()
    {
        CurrentLevel.currentLevel.OnclickLevelButton(CurrentLevel.currentLevel.CurrentLevelNo + 1);
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
