using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : LevelsManager
{

    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnclickLevelButton(int ind)
    {
        throw new System.NotImplementedException();
    }
    //public void abstract OnCLickLevelButton()
    //{

    //    base.CreateLevel(levelNo,SpawnedZombies,Reward);
    //}
}
