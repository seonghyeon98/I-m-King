using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 아이템의 상호작용을 구현한다.
// 아이템의 각 종류를 정한다. {하트,특수 총, 총알} 


public class Item : MonoBehaviour
{
    public enum Type { Heart, Ammo, Rifle }
    public Type type;

    //물체 움직임 속도
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
        // 아이템이 회전하면서 위아래로 움직이고 싶다.

        // 2. 아이템이 올라가기
        // 1. 항상 회전한다
        transform.Rotate(Vector3.up * 180 * Time.deltaTime);


        // 2. 아이템이 올라가기
        transform.position += dir * speed * Time.deltaTime;

        // 일정 위치에 도달했는지 체크한다.
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
            // 2. 아이템이 올라가기
            transform.position += Vector3.up * speed * Time.deltaTime;
           
            // 일정 위치에 도달했는지 체크한다.
            Vector3 temp0 = aaa + Vector3.up * dis;
            if (temp0.y <= transform.position.y)
            {
                // 만약 도달하면 반대로 가게 된다
                isUP = false;
                //transform.position += Vector3.down * speed * Time.deltaTime;
            }
        }

        else
        {
            // 아래로 내려가기
            transform.position += Vector3.down * speed * Time.deltaTime;
            
            // 일정 거리까지 내려갔는지 체크한다

            Vector3 temp = aaa + Vector3.down * dis;
            if (temp.y >= transform.position.y)
            {
                // 다시 반대로
                isUP = true;
            }
            
        }
        */

        
    }
}
