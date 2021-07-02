using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �������� ��ȣ�ۿ��� �����Ѵ�.
// �������� �� ������ ���Ѵ�. {��Ʈ,Ư�� ��, �Ѿ�} 


public class Item : MonoBehaviour
{
    public enum Type { Heart, Ammo, Rifle }
    public Type type;

    //��ü ������ �ӵ�
    public float speed = 1.0f;

    Vector3 aaa;
    public float dis = 3;

    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        aaa = transform.position;
        dir = Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
        // �������� ȸ���ϸ鼭 ���Ʒ��� �����̰� �ʹ�.

        // 2. �������� �ö󰡱�
        // 1. �׻� ȸ���Ѵ�
        transform.Rotate(Vector3.up * 180 * Time.deltaTime);


        // 2. �������� �ö󰡱�
        transform.position += dir * speed * Time.deltaTime;

        // ���� ��ġ�� �����ߴ��� üũ�Ѵ�.
        Vector3 temp0 =  aaa + dir * (dir.y > 0 ? dis :0);
        if (dir.y > 0)
        {
            if (temp0.y <= transform.position.y)
                dir = Vector3.down;

        }
        else
        {
            if (temp0.y >= transform.position.y)
                dir = Vector3.up;

        }

        /*
        if (isUP == true)
        {
            // 2. �������� �ö󰡱�
            transform.position += Vector3.up * speed * Time.deltaTime;
           
            // ���� ��ġ�� �����ߴ��� üũ�Ѵ�.
            Vector3 temp0 = aaa + Vector3.up * dis;
            if (temp0.y <= transform.position.y)
            {
                // ���� �����ϸ� �ݴ�� ���� �ȴ�
                isUP = false;
                //transform.position += Vector3.down * speed * Time.deltaTime;
            }
        }

        else
        {
            // �Ʒ��� ��������
            transform.position += Vector3.down * speed * Time.deltaTime;
            
            // ���� �Ÿ����� ���������� üũ�Ѵ�

            Vector3 temp = aaa + Vector3.down * dis;
            if (temp.y >= transform.position.y)
            {
                // �ٽ� �ݴ��
                isUP = true;
            }
            
        }
        */

        
    }
}
