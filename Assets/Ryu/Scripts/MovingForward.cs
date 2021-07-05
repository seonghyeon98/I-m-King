using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//앞으로 이동한다.

//f)

//    speed
//m)
//	MoveForward()
public class MovingForward : MonoBehaviour
{
    [SerializeField] float speed;

    private void Update()
    {
        MoveForward();
    }

    void MoveForward()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
