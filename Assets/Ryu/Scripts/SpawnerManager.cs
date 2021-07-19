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

//�ʵ忡 ���Ͱ� ������ ����. ������ �� ������ �ֱ�,  ������ �� ��ƼŬ �־��ֱ�
//�� �����Ҷ� ������ ���� �þ����. -> �ι�?


public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private EnemySpwaner[] enemySpawners;
    [SerializeField] private BossSpwaner bossSpawner;
    [SerializeField] private AliveEnemyManager enemyManager;

    //���̺�
    private int wave = 0;

    // �Ű����� & ����
    // ����(��ȯ Ÿ��)

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        StartCoroutine(Co_Spawn());
    }

    private IEnumerator Co_Spawn()
    {
        wave += 1;

        yield return new WaitForSeconds(1);

        if(wave % 5 == 0)
        {
            SpawnBoss();
        }
        else
        {
            SpawnEnemy();
        }
    }
    private void SpawnEnemy()
    {
        int spawnNum = GetSpawnNum();
        List<int> randomPos = GetRandomPos(spawnNum);

        for (int i = 0; i < randomPos.Count; i++)
        {
            enemySpawners[randomPos[i]].Spawn();
        }
    }

    private List<int> GetRandomPos(int spawnNum)
    {
        // �������� ���� ���� �����صδ� ����Ʈ
        List<int> randomPos = new List<int>();

        spawnNum = spawnNum >= enemySpawners.Length ? enemySpawners.Length : spawnNum;

        // spawnNum��ŭ �ߺ� ���� ������ ����
        for (int i = 0; i < spawnNum; i++)
        {
            // �������� ���� �ӽ� ��
            int temp = Random.Range(0, enemySpawners.Length - i);

            // ������ ���� ���� ������ ��ȸ
            bool isOverlap = false;            
            do
            {
                isOverlap = false;
                for (int j = 0; j < randomPos.Count; j++)
                {
                    if (randomPos[j] == temp)
                    {
                        temp = enemySpawners.Length - (j + 1);
                        isOverlap = true;
                        break;
                    }
                }
            }
            while (isOverlap);

            randomPos.Add(temp);
        }

        return randomPos;
    }

    private int GetSpawnNum()
    {
        // ���̺꿡 ���� ������ ����
        return (wave) * 1;
    }

    private void SpawnBoss()
    {
        // ���� ���� ���
        bossSpawner.Spawn();
    }
}