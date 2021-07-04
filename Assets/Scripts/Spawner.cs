using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] protected Transform pool;

    public void Spawn()
    {
        // 그리고 enemys배열안에 ranNum번째 친구를 '생성' 한다.
        GameObject ranEnemy = Instantiate(SelectSpawnObj());

        // 생성한 친구를 에너미스포너에 가져와 놓는다
        ranEnemy.transform.position = transform.position;
        ranEnemy.transform.parent = pool;

        ranEnemy.GetComponent<SpawnComponent>().Spawn();
    }

    protected abstract GameObject SelectSpawnObj();
}