using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : HPComponent
{
    protected override void TakeDamage()
    {
        // �ǰ� �ִϸ��̼�
        // ���� ȣ��
        // HP UI ����
    }

    protected override void Heal()
    {
        // ȸ�� ��ƼŬ
    }

    protected override void Death()
    {
        Destroy(this.gameObject);
    }
}
