using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-> 어떤 적을 생성할건지 랜덤 결정
//-> 적 프리팹을 가져와서 자기 위치에 생성한다

//Spawn() 적을 자기 위치(EnemySpawner)에 가져다 놓는다
//	RandomSpawn() SelectSpawnObj()

//    확률을 뽑아서 만약 근접형이 나올 경우 원거리가 나올 경우  각각 그에 맞는 애로 생성한다

public class EnemySpwaner : MonoBehaviour
{

    [SerializeField] GameObject[] enemys;
     

    public void Spawn()
    {
        // 적을 자기 위치에 가져다 놓는다
        
    }

    void SelectSpawnObj()
    {

    }
}
