using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : HPComponent
{
    [SerializeField] AliveEnemyManager aliveEnemyManager;
    // 죽을 때 떨굴 아이템 종류
    [SerializeField] GameObject[] items;

    private new void Awake()
    {
        base.Awake();

        aliveEnemyManager = GameObject.Find("EnemyManager").GetComponent<AliveEnemyManager>();
    }

    protected override void TakeDamage(float delta)
    {
        // 피격 애니메이션
        // 사운드 호출
        // HP UI 갱신
        print(CurrentHP);
    }

    protected override void Heal(float delta)
    {
        // 회복 파티클
    }

    protected override void Death()
    {
        print("Death");
        aliveEnemyManager.Remove(this.gameObject);
        Destroy(this.gameObject);
        // 죽을 때 아이템 떨군다
        GameObject item = Instantiate(items[0]);

        // 3. 총구 위치에 가져다 놓고 싶다.
        item.transform.position = transform.position;
    }
}
