using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 부딪힐 때 삭제하고 싶다
//m)
//	OnCollisionDestroy()

public class CollisionDestroy : MonoBehaviour
{
    [SerializeField] LayerMask collisionTargetLayer;

    private void OnTriggerEnter(Collider other)
    {
        if ((LayerMask.GetMask(LayerMask.LayerToName(other.gameObject.layer)) & collisionTargetLayer.value) != 0)
        {
            Destroy(this.gameObject);
        }
    }
}
