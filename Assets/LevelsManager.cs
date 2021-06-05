using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class LevelsManager : MonoBehaviour
{
    public int SpawnedZombies;
    public int Reward;
    public int levelNo;
    public GameObject ZombiePrefabs;
    public Transform[] spawnLocations;
    [HideInInspector]
    private CurrentLevel currentLevel;
    protected virtual void Start()
    {
        currentLevel = FindObjectOfType<CurrentLevel>();
    }


    public virtual void CreateLevel(int _levelNo,int spawnedZombies,int reward,GameObject zombie)
    {
        
        levelNo = _levelNo;
        SpawnedZombies = spawnedZombies;
        Reward = reward;
        ZombiePrefabs = zombie;
        SceneManager.LoadScene(1);


    }

    public abstract void OnclickLevelButton(int ind);
   
}
