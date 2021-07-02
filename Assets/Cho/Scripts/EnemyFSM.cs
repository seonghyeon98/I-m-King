using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    // 열거
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

    // 대기 상태 함수
    void Idle()
    { 
        
    }

    // 이동 상태 함수
    void Move()
    { 
    
    }

    // 근접 공격 상태 함수
    void ShortRangeAttack()
    { 
    
    }

    // 원거리 공격 상태 함수
    void LongRangeAttack()
    { 
    
    }

    // 피격 상태 함수
    void Damaged()
    { 
    
    }

    // 사망 상태 함수
    void Die()
    { 
    
    }
}