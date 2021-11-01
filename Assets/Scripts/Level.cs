using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int SpawnedZombies=2;
    public int Reward=1000;
    public GameObject ZombiePrefabs;
    public Transform[] spawnLocations;


    private void Start()
    {
        for (int i = 0; i < SpawnedZombies; i++)
        {
            int rand = Random.Range(0, spawnLocations.Length);
            Instantiate(ZombiePrefabs,spawnLocations[rand].position, spawnLocations[rand].rotation);

        }
    }
}
