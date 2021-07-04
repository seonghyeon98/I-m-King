using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-> � ���� �����Ұ��� ���� ����
//-> �� �������� �����ͼ� �ڱ� ��ġ�� �����Ѵ�

//Spawn() ���� �ڱ� ��ġ(EnemySpawner)�� ������ ���´�
//	RandomSpawn() SelectSpawnObj()

//  Ȯ���� �̾Ƽ� ���� �������� ���� ��� ���Ÿ��� ���� ���  ���� �׿� �´� �ַ� �����Ѵ�

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
