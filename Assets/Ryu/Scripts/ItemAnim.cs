using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class ItemAnim : MonoBehaviour
{


    //��ü ������ �ӵ�
    public float speed = 1.0f;

    Vector3 originPos;
    public float dis = 3;

    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        originPos = transform.position;
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

        if (dir == Vector3.up)
        {
            float targetPosY = originPos.y + dis;
            if (targetPosY <= transform.position.y)
                dir = Vector3.down;

        }
        else
        {
            if (originPos.y >= transform.position.y)
                dir = Vector3.up;
        }

        
    }
}
