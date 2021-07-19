using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-> 스포너들을 관리한다
//-> 어떤 스포너에서 생성시킬지 정해서 해당 스포너에게 전달
//-> 웨이브에 따라 생성량 결정
//-> 보스 생성 명령

//	enemyspawners, BossSpawner, 웨이브

//	RandomSpawnerPos() SpawnEnemy() 스포너들중 랜덤으로 골라준다
//	EnemyWave() GetSpawnNum() 적의 생성 수를 관리한다
//	SpawnBoss()

//필드에 몬스터가 없으면 스폰. 스폰할 때 딜레이 주기,  스폰할 때 파티클 넣어주기
//재 생성할때 전보다 양이 늘어야함. -> 두배?


public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private EnemySpwaner[] enemySpawners;
    [SerializeField] private BossSpwaner bossSpawner;
    [SerializeField] private AliveEnemyManager enemyManager;

    //웨이브
    private int wave = 0;

    // 매개변수 & 인자
    // 리턴(반환 타입)

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
        // 랜덤으로 나온 값을 저장해두는 리스트
        List<int> randomPos = new List<int>();

        spawnNum = spawnNum >= enemySpawners.Length ? enemySpawners.Length : spawnNum;

        // spawnNum만큼 중복 없이 랜덤값 뽑음
        for (int i = 0; i < spawnNum; i++)
        {
            // 랜덤으로 나온 임시 값
            int temp = Random.Range(0, enemySpawners.Length - i);

            // 사전에 나온 랜덤 값들을 조회
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
        // 웨이브에 따라 생성량 결정
        return (wave) * 1;
    }

    private void SpawnBoss()
    {
        // 보스 생성 명령
        bossSpawner.Spawn();
    }
}