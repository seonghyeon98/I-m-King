using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHP : HPComponent
{
    [SerializeField] AliveEnemyManager aliveEnemyManager;
    // 죽을 때 떨굴 아이템 종류
    [SerializeField] GameObject[] items;
    [SerializeField] Animator animator;
    private new void Awake()
    {
        base.Awake();

        aliveEnemyManager = GameObject.Find("EnemyManager").GetComponent<AliveEnemyManager>();
    }

    protected override void TakeDamage(float delta)
    {
        // 피격 애니메이션
        animator.SetTrigger("DoHit");
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
        StartCoroutine(Co_Death());
    }

    IEnumerator Co_Death()
    {
        animator.SetTrigger("DoDie");
        aliveEnemyManager.Remove(this.gameObject);
        GetComponent<Collider>().enabled = false;
        GetComponent<EnemyFSM>().enabled = false;
        GetComponent<NavMeshAgent>().velocity = Vector3.zero;
        GetComponent<NavMeshAgent>().enabled = false;

        yield return new WaitForSeconds(2f);

        Destroy(this.gameObject);
        // 죽을 때 아이템 떨군다
        GameObject item = Instantiate(items[0]);

        // 3. 총구 위치에 가져다 놓고 싶다.
        item.transform.position = transform.position;
    }
}
