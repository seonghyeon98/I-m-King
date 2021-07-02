using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    // ����
    enum EnemyState
    {
        Idle,
        Move,
        ShortRangeAttack,
        LongRangeAttack,
        Damaged,
        Die
    }

    EnemyState eState;

    void Start()
    {

    }

    void Update()
    {
        switch (eState)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Move:
                Move();
                break;
            case EnemyState.ShortRangeAttack:
                ShortRangeAttack();
                break;
            case EnemyState.LongRangeAttack:
                LongRangeAttack();
                break;
            case EnemyState.Damaged:
                Damaged();
                break;
            case EnemyState.Die:
                Die();
                break;
            default:
                break;
        }
    }

    // ��� ���� �Լ�
    void Idle()
    { 
        
    }

    // �̵� ���� �Լ�
    void Move()
    { 
    
    }

    // ���� ���� ���� �Լ�
    void ShortRangeAttack()
    { 
    
    }

    // ���Ÿ� ���� ���� �Լ�
    void LongRangeAttack()
    { 
    
    }

    // �ǰ� ���� �Լ�
    void Damaged()
    { 
    
    }

    // ��� ���� �Լ�
    void Die()
    { 
    
    }
}