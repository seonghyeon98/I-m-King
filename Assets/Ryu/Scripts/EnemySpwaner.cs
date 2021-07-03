using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-> 어떤 적을 생성할건지 랜덤 결정
//-> 적 프리팹을 가져와서 자기 위치에 생성한다

//Spawn() 적을 자기 위치(EnemySpawner)에 가져다 놓는다
//	RandomSpawn() SelectSpawnObj()

//  확률을 뽑아서 만약 근접형이 나올 경우 원거리가 나올 경우  각각 그에 맞는 애로 생성한다

public class EnemySpwaner : MonoBehaviour
{
    [SerializeField] GameObject[] enemys;

    public void Spawn()
    {
        // 에너미 배열 길이만큼 랜덤으로 수를 하나 뽑아
        int ranNum = Random.Range(0, enemys.Length);
        // 그리고 enemys배열안에 ranNum번째 친구를 '생성' 한다.
        GameObject ranEnemy = Instantiate(enemys[ranNum]);
        // 생성한 친구를 에너미스포너에 가져와 놓는다
        ranEnemy.transform.position = transform.position;
    }
}
