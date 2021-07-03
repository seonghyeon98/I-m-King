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

//필드에 몬스터가 없으면 스폰.
//재 생성할때 전보다 양이 늘어야함. -> 두배?


public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private EnemySpwaner[] enmeySpawners;
    [SerializeField] private BossSpwaner bossSpawner;
    
    //웨이브
    private int wave = 0;
    


    // 매개변수 & 인자
    // 리턴(반환 타입)


    private void SpawnEnemy()
    {
        // 스포너들을 랜덤으로 골라준다.



    }



    private int GetSpawnNum()
    {
        // 웨이브에 따라 생성량 결정
        //
        return 0;
    }

    private void SpawnBoss()
    {
        // 보스 생성 명령
        bossSpawner.Spawn();
    }
}