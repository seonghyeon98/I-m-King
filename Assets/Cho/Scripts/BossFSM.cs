using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossFSM : MonoBehaviour
{
    public GameObject bossAttack;
    public float fireDelay = 0.5f;
    public float moveSpeed = 7f;
    public float patternTime = 2f;
    public float stopRange = 15f;

    Transform player;
    float currentFireTime;
    float currentPatternTime;


    NavMeshAgent smith;

    // 보스 패턴 열거 상수
    public enum BossState
    {
        Idle,
        Pattern1,
        Pattern2,
        Pattern3
    }

    BossState bossState;

    void Start()
    {
        // 기본 상태는 대기 상태
        bossState = BossState.Idle;

        // 플레이어의 위치 찾기
        player = GameObject.Find("Player").transform;

        // NavMeshAgent 컴포넌트를 가져온다.
        smith = GetComponent<NavMeshAgent>();
        smith.speed = moveSpeed;
        smith.acceleration = 20.0f;
        smith.stoppingDistance = stopRange;
    }

    void Update()
    {
        switch (bossState)
        {
            case BossState.Idle:
                break;
            case BossState.Pattern1:
                Pattern1();
                break;
            case BossState.Pattern2:
                break;
            case BossState.Pattern3:
                break;
            default:
                break;
        }
    }

    // 패턴 1) 플레이어쪽으로 이동하면서 patternTime 동안 여러 갈래로 공격을 하고 싶다.
    void Pattern1()
    {
        currentFireTime += Time.deltaTime;
        currentPatternTime += Time.deltaTime;

        Vector3 targetPos = new Vector3(player.position.x, transform.position.y, player.position.z);

        // 계속 플레이어를 쳐다본다.
        transform.LookAt(targetPos);

        smith.enabled = true;
        // 플레이어의 위치를 NavMesh의 목적지로 설정한다.
        smith.SetDestination(player.position);

        // 만약, currentPatternTime 이 patternTime 보다 작다면
        if (currentPatternTime <= patternTime)
        {
            // 딜레이 마다 여러 갈래로 공격한다.
            if (currentFireTime >= fireDelay)
            {
                // firePos
                Vector3 firePos = transform.GetChild(0).position;
                Quaternion fireRot = transform.GetChild(0).rotation;

                currentFireTime = 0;
            }
        }
        // 커지면 다른 패턴을 실행한다.
        else
        {
            currentPatternTime = 0;
        }
    }
}
