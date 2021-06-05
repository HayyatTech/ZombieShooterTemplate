using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CurrentLevel : Level
{
    public static CurrentLevel currentLevel;
    public Transform SpawnLocParent;
    public Level[] levelsdata;
    [HideInInspector] public int CurrentLevelNo;
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnsceneLoad;

    }

    private void OnsceneLoad(Scene arg0, LoadSceneMode arg1)
    {
        if (arg0.buildIndex > 0)
        {
            SpawnLocParent = GameObject.FindGameObjectWithTag("SpawnLoc").transform;
            spawnLocations = SpawnLocParent.GetComponentsInChildren<Transform>();
            InIt();
        }
      
    }

    void Start()
    {
        if (currentLevel == null)
        {
            currentLevel = this;
        }
        DontDestroyOnLoad(currentLevel);
      
    }

    private void InIt()
    {
        Debug.Log("init");
        for (int i = 0; i < SpawnedZombies; i++)
        {
            int rand = UnityEngine.Random.Range(1, spawnLocations.Length - 1);
            Debug.Log("called");
            Instantiate(ZombiePrefabs, spawnLocations[rand].position, Quaternion.identity);
        }
      
    }

    public override void OnclickLevelButton(int ind)
    {
        for(int i = 0; i < levelsdata.Length; i++)
        {
            if (ind == i)
            {

                // levelNo = levelsdata[i].levelNo;
                // Debug.Log(levelNo);
                CurrentLevelNo = i;

                base.CreateLevel(levelsdata[i].levelNo,levelsdata[i].SpawnedZombies, levelsdata[i].Reward,levelsdata[i].ZombiePrefabs);
            }
        }
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnsceneLoad;
    }
}
