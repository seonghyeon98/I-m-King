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

    [SerializeField] Rigidbody rigidbody;

    void Start()
    {
        //player = GameObject.Find("Player").transform;

        //dir = player.position - transform.position;
        //dir.Normalize();

        rot = Quaternion.Euler(0, transform.eulerAngles.y, 0);

        dir = rot * Vector3.forward;
        dir.Normalize();
    }

    void Update()
    {
        //dir = transform.TransformDirection(dir);
        //transform.position += dir * bulletSpeed * Time.deltaTime;

        rigidbody.velocity = dir * bulletSpeed;
    }
}
