using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnComponent : MonoBehaviour
{
    [SerializeField] AliveEnemyManager aliveEnemyManager;

    void Awake()
    {
        aliveEnemyManager = GameObject.Find("EnemyManager").GetComponent<AliveEnemyManager>();
    }

    public void Spawn()
    {
        aliveEnemyManager.Add(this.gameObject);

        // 파티클
        // 애니메이션
        // 사운드
        // 체력 초기화
    }
}
