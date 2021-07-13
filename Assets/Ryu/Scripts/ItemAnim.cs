using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class ItemAnim : MonoBehaviour
{


    //물체 움직임 속도
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
        // 아이템이 회전하면서 위아래로 움직이고 싶다.

        // 2. 아이템이 올라가기
        // 1. 항상 회전한다
        transform.Rotate(Vector3.up * 180 * Time.deltaTime);


        // 2. 아이템이 올라가기
        transform.position += dir * speed * Time.deltaTime;

        // 일정 위치에 도달했는지 체크한다.

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
