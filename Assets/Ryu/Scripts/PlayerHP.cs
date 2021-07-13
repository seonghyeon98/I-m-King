using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : HPComponent
{
    [SerializeField] HPBar hpBar;

    protected override void TakeDamage(float delta)
    {
        // �ǰ� �ִϸ��̼�
        // ���� ȣ��
        // HP UI ����
    }

    protected override void Heal(float delta)
    {
        // ȸ�� ��ƼŬ
    }

    protected override void Death()
    {
        this.gameObject.SetActive(false);
    }

    protected override void RefreshUIElement()
    {
        hpBar.ApplyHPBarUI(CurrentHP / maxHP);
    }
}