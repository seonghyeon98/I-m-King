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
        // �ǰ� �ִϸ��̼�
        // ���� ȣ��
        // HP UI ����
        print(CurrentHP);
    }

    protected override void Heal()
    {
        // ȸ�� ��ƼŬ
    }

    protected override void Death()
    {
        print("Death");
        aliveEnemyManager.Remove(this.gameObject);
        Destroy(this.gameObject);
    }
}
