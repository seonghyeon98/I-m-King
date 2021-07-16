using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackAction : MonoBehaviour
{
    public float bulletSpeed = 5.0f;

    //Transform player;
    //Vector3 dir;
    Quaternion rot;
    Vector3 dir;

    // 공격의 종류
    public enum AttackType
    {
        EnemyAttack,
        BossAttack
    }

    public AttackType attackType = AttackType.EnemyAttack;

    void Start()
    {
        //player = GameObject.Find("Player").transform;

        //dir = player.position - transform.position;
        //dir.Normalize();


        if (attackType == AttackType.EnemyAttack)
        {
            rot = Quaternion.Euler(0, transform.eulerAngles.y, 0);

            dir = rot * Vector3.forward;
            dir.Normalize();
        }
        else if (attackType == AttackType.BossAttack)
        {
            dir = transform.forward;
            dir.Normalize();
        }
    }

    void Update()
    {
        //dir = transform.TransformDirection(dir);
        //transform.position += dir * bulletSpeed * Time.deltaTime;

        transform.position += dir * bulletSpeed * Time.deltaTime;
    }
}
