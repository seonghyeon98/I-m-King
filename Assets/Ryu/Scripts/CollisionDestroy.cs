using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// �ε��� �� �����ϰ� �ʹ�
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
