using JHS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// �÷��̾�� ������ ��ȸ�������ٰž߸�������

public class ItemHeal : TriggerEnterFrame
{
    //ȸ����
    [SerializeField] int heal = 10;

    // �÷��̾�� ������
    protected override void TriggerEnter(Collider other)
    {
        //��ȸ���Ұž�
        other.gameObject.GetComponent<HPComponent>().CurrentHP += heal;
        print("ü�� ȸ��~!");
        // a += b;
        // a = a + b;
    }

}
