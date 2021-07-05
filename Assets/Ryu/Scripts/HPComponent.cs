using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HPComponent : MonoBehaviour
{
    [SerializeField] float maxHP;
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
            if (currentHP < value)
            {
                currentHP = value;
                Heal();
            }
            if (currentHP > value)
            {
                currentHP = value;
                TakeDamage();

                if (value <= 0)
                {
                    currentHP = 0;
                    Death();
                }
            }
        }
    }

    protected virtual void TakeDamage() { }

    protected virtual void Heal() { }

    protected virtual void Death() { }
}
