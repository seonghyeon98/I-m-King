using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHP : HPComponent
{
    [SerializeField] AliveEnemyManager aliveEnemyManager;
    // ���� �� ���� ������ ����
    [SerializeField] GameObject[] items;
    [SerializeField] Animator animator;
    private new void Awake()
    {
        base.Awake();

        aliveEnemyManager = GameObject.Find("EnemyManager").GetComponent<AliveEnemyManager>();
    }

    protected override void TakeDamage(float delta)
    {
        // �ǰ� �ִϸ��̼�
        animator.SetTrigger("DoHit");
        // ���� ȣ��
        // HP UI ����
        print(CurrentHP);
    }

    protected override void Heal(float delta)
    {
        // ȸ�� ��ƼŬ
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
        // ���� �� ������ ������
        GameObject item = Instantiate(items[0]);

        // 3. �ѱ� ��ġ�� ������ ���� �ʹ�.
        item.transform.position = transform.position;
    }
}
