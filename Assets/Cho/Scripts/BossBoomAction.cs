using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBoomAction : MonoBehaviour
{
    public float attackDamage = 10f;
    public GameObject smoke;

    void Start()
    {
        Explosion();
    }

    void Explosion()
    {
        RaycastHit[] rayhits = Physics.SphereCastAll(transform.position, 10, Vector3.up, 0f, LayerMask.GetMask("Player"));

        // ��ź ���� ���ΰ��� �ǰ� �Լ� ȣ��
        foreach (RaycastHit hitObj in rayhits)
        {
            HPComponent hpComponent = hitObj.transform.GetComponent<HPComponent>();
            if (hpComponent)
            {
                print("��ź ������");
                hpComponent.CurrentHP -= attackDamage;
            }
        }

        Instantiate(smoke, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
