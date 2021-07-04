using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 보스를 소환하고 싶다


public class BossSpwaner : Spawner
{
    [SerializeField] GameObject boss;

    protected override GameObject SelectSpawnObj()
    {
        return boss;
    }
}
