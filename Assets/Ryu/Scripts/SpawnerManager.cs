using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-> �����ʵ��� �����Ѵ�
//-> � �����ʿ��� ������ų�� ���ؼ� �ش� �����ʿ��� ����
//-> ���̺꿡 ���� ������ ����
//-> ���� ���� ���

//	enemyspawners, BossSpawner, ���̺�

//	RandomSpawnerPos() SpawnEnemy() �����ʵ��� �������� ����ش�
//	EnemyWave() GetSpawnNum() ���� ���� ���� �����Ѵ�
//	SpawnBoss()



public class SpawnerManager : MonoBehaviour
{
    [SerializeField] EnemySpwaner[] enmeySpawners;
    [SerializeField] BossSpwaner bossSpawner;
    int wave = 0;

    // �Ű����� & ����
    // ����(��ȯ Ÿ��)

    void SpawnEnemy()
    {
        //����¯123
    }

  

    int GetSpawnNum()
    {
        // ���̺꿡 ���� ������ ����
        //
        return 0;
    }

    void SpawnBoss()
    {
        // ���� ���� ���
        bossSpawner.Spawn();
    }
}
