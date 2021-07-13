using JHS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 플레이어와 닿으면 피회복시켜줄거야말리지마

public class ItemHeal : TriggerEnterFrame
{
    //회복량
    [SerializeField] int heal = 10;

    // 플레이어랑 닿으면
    protected override void TriggerEnter(Collider other)
    {
        //피회복할거야
        other.gameObject.GetComponent<HPComponent>().CurrentHP += heal;
        print("체력 회복~!");
        // a += b;
        // a = a + b;
    }

}
