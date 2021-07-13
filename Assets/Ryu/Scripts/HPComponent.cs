using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HPComponent : MonoBehaviour
{
    [SerializeField] protected float maxHP;
    float currentHP;

    protected void Awake()
    {
        currentHP = maxHP;
    }

    // ������Ƽ
    public float CurrentHP
    {
        get { return currentHP; }
        set
        {
            if (currentHP > value && currentHP <= 0) return;                    // �̹� ü���� 0 �����ε� �������� ���� ��
            float delta = Mathf.Abs(currentHP - value);
            if (currentHP < value) Heal(delta);                                 // ü���� ȸ�� ���� ��
            if (currentHP > value && value > 0) TakeDamage(delta);              // �������� �Ծ����� ���� �ʾ��� ��
            currentHP = Mathf.Clamp(value, 0, maxHP); RefreshUIElement();         // HP ����ġ ����
            if (currentHP <= 0) Death();                                        // ü�� 0 ���� �� ���
        }
    }

    protected virtual void RefreshUIElement() { }

    protected virtual void TakeDamage(float delta) { }

    protected virtual void Heal(float delta) { }

    protected virtual void Death() { }
}
