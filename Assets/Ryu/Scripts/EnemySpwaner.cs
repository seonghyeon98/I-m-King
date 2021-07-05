using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-> 어떤 적을 생성할건지 랜덤 결정
//-> 적 프리팹을 가져와서 자기 위치에 생성한다

//Spawn() 적을 자기 위치(EnemySpawner)에 가져다 놓는다
//	RandomSpawn() SelectSpawnObj()

//  확률을 뽑아서 만약 근접형이 나올 경우 원거리가 나올 경우  각각 그에 맞는 애로 생성한다

[System.Serializable]
public class SpawnObj 
{
    public GameObject obj;
    public float prob;
}

public class EnemySpwaner : Spawner
{
    [SerializeField] SpawnObj[] enemys;
    
    protected override GameObject SelectSpawnObj()
    {
        float total = 0;

        foreach (SpawnObj spawnObj in enemys)
        {
            total += spawnObj.prob;
        }

        float randomPoint = Random.value * total;

        for (int i = 0; i < enemys.Length; i++)
        {
            if (randomPoint < enemys[i].prob)
            {
                return enemys[i].obj;
            }
            else
            {
                randomPoint -= enemys[i].prob;
            }
        }
        return enemys[enemys.Length - 1].obj;
    }   
}
