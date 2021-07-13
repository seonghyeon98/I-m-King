using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : HPComponent
{
    [SerializeField] AliveEnemyManager aliveEnemyManager;
    // ���� �� ���� ������ ����
    [SerializeField] GameObject[] items;

    private new void Awake()
    {
        base.Awake();

        aliveEnemyManager = GameObject.Find("EnemyManager").GetComponent<AliveEnemyManager>();
    }

    protected override void TakeDamage(float delta)
    {
        // �ǰ� �ִϸ��̼�
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
        print("Death");
        aliveEnemyManager.Remove(this.gameObject);
        Destroy(this.gameObject);
        // ���� �� ������ ������
        GameObject item = Instantiate(items[0]);

        // 3. �ѱ� ��ġ�� ������ ���� �ʹ�.
        item.transform.position = transform.position;
    }
}
