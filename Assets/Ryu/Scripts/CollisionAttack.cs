using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 부딪힐 때 데미지를 준다

//f) 
//	collisionTarget
//    attackDamage
//m)
//	OnCollisionAttack()

public class CollisionAttack : MonoBehaviour
{    
    [SerializeField] float attackDamage;
    [SerializeField] LayerMask collisionTargetLayer;

    private void OnTriggerEnter(Collider other)
    {
        print("충돌");
        if ((LayerMask.GetMask(LayerMask.LayerToName(other.gameObject.layer)) & collisionTargetLayer.value) != 0)
        {
            print($"{attackDamage}만큼 데미지를 입혔습니다.");
            HPComponent hpComponent = other.gameObject.GetComponent<HPComponent>();
            if (hpComponent)
            {
                hpComponent.CurrentHP -= attackDamage;
            }            
        }
    }

    public void Attack(Collider other)
    {
        if ((LayerMask.GetMask(LayerMask.LayerToName(other.gameObject.layer)) & collisionTargetLayer.value) != 0)
        {
            print($"{attackDamage}만큼 데미지를 입혔습니다.");
            HPComponent hpComponent = other.gameObject.GetComponent<HPComponent>();
            if (hpComponent)
            {
                hpComponent.CurrentHP -= attackDamage;
            }
        }
    }
}
