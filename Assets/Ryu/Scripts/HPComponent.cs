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

    // 프로퍼티
    public float CurrentHP
    {
        get { return currentHP; }
        set
        {
            if (currentHP > value && currentHP <= 0) return;                    // 이미 체력이 0 이하인데 데미지를 입을 시
            float delta = Mathf.Abs(currentHP - value);
            if (currentHP < value) Heal(delta);                                 // 체력이 회복 됬을 시
            if (currentHP > value && value > 0) TakeDamage(delta);              // 데미지를 입었지만 죽지 않았을 시
            currentHP = Mathf.Clamp(value, 0, maxHP); RefreshUIElement();         // HP 변동치 적용
            if (currentHP <= 0) Death();                                        // 체력 0 이하 시 사망
        }
    }

    protected virtual void RefreshUIElement() { }

    protected virtual void TakeDamage(float delta) { }

    protected virtual void Heal(float delta) { }

    protected virtual void Death() { }
}
