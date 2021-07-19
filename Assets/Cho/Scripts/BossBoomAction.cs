using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBoomAction : MonoBehaviour
{
    public float attackDamage = 10f;

    void Start()
    {
        Explosion();
    }

    void Explosion()
    {
        RaycastHit[] rayhits = Physics.SphereCastAll(transform.position, 15, Vector3.up, 0f, LayerMask.GetMask("Player"));

        // 폭탄 범위 주인공의 피격 함수 호출
        foreach (RaycastHit hitObj in rayhits)
        {
            HPComponent hpComponent = hitObj.transform.GetComponent<HPComponent>();
            if (hpComponent)
            {
                print("폭탄 데미지");
                hpComponent.CurrentHP -= attackDamage;
            }
        }

        Destroy(gameObject);
    }
}
