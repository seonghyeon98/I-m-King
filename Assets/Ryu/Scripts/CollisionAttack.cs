using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �ε��� �� �������� �ش�

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
        if ((LayerMask.GetMask(LayerMask.LayerToName(other.gameObject.layer)) & collisionTargetLayer.value) != 0)
        {
            print($"{attackDamage}��ŭ �������� �������ϴ�.");
            HPComponent hpComponent = other.gameObject.GetComponent<HPComponent>();
            if (hpComponent)
            {
                hpComponent.CurrentHP -= attackDamage;
            }            
        }
    }
}
