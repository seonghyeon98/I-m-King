using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackAction : MonoBehaviour
{
    public float bulletSpeed = 5.0f;

    Transform player;
    //Vector3 dir;
    Quaternion rot;
    Vector3 moveDir;

    void Start()
    {
        player = GameObject.Find("Player").transform;

        //dir = player.position - transform.position;
        //dir.Normalize();

        rot = Quaternion.Euler(0, transform.eulerAngles.y, 0);

        moveDir = rot * Vector3.forward;
    }

    void Update()
    {
        //dir = transform.TransformDirection(dir);
        //transform.position += dir * bulletSpeed * Time.deltaTime;

        transform.position += moveDir * bulletSpeed * Time.deltaTime;
    }
}
