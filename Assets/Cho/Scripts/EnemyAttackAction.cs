using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackAction : MonoBehaviour
{
    public float bulletSpeed = 5.0f;

    Transform player;
    Vector3 dir;

    void Start()
    {
        player = GameObject.Find("Player").transform;

        dir = player.position - transform.position;
        dir.Normalize();
    }

    void Update()
    {
        //dir = transform.TransformDirection(dir);
        transform.position += dir * bulletSpeed * Time.deltaTime;
    }
}
