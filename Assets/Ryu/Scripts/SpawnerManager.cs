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

//�ʵ忡 ���Ͱ� ������ ����.
//�� �����Ҷ� ������ ���� �þ����. -> �ι�?


public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private EnemySpwaner[] enmeySpawners;
    [SerializeField] private BossSpwaner bossSpawner;
    
    //���̺�
    private int wave = 0;
    


    // �Ű����� & ����
    // ����(��ȯ Ÿ��)


    private void SpawnEnemy()
    {
        // �����ʵ��� �������� ����ش�.



    }



    private int GetSpawnNum()
    {
        // ���̺꿡 ���� ������ ����
        //
        return 0;
    }

    private void SpawnBoss()
    {
        // ���� ���� ���
        bossSpawner.Spawn();
    }
}