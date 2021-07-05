using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : HPComponent
{
    [SerializeField] AliveEnemyManager aliveEnemyManager;

    private new void Awake()
    {
        base.Awake();

        aliveEnemyManager = GameObject.Find("EnemyManager").GetComponent<AliveEnemyManager>();
    }

    protected override void TakeDamage()
    {
        // 피격 애니메이션
        // 사운드 호출
        // HP UI 갱신
        print(CurrentHP);
    }

    protected override void Heal()
    {
        // 회복 파티클
    }

    protected override void Death()
    {
        print("Death");
        aliveEnemyManager.Remove(this.gameObject);
        Destroy(this.gameObject);
    }
}
