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

        // 웨이브가 시작 되면 
        if (wave)
        {

        }
        // enmeySpawners 배열들 중에서 랜덤으로 스폰 위치를 잡아 스폰한다.
        // 몬스터들을 소환할 때 게임오브젝트 배열에 담는다.
        // 몬스터들이 다 쥬그믄 다음 웨이브 시작.
        // 몬스터들이 죽을 때, 게임오브젝트 배열에서 삭제한다.

        //다음 웨이브는 게임오브젝트 배열의 길이가0일때 시작된다.
        // 다음 웨이브 때는 몬스터가 증가한데연
    }



    private int GetSpawnNum()
    {
        // 웨이브에 따라 생성량 결정
        return 0;
    }

    private void SpawnBoss()
    {
        // 보스 생성 명령
        bossSpawner.Spawn();
    }
}