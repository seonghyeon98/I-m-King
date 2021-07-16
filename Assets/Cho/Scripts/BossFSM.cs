using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossFSM : MonoBehaviour
{
    public GameObject bossAttack;
    public GameObject bossBoom;
    public float fireDelay = 0.5f;
    public float moveSpeed = 7f;
    public float patternTime = 2f;
    public float stopRange = 15f;
    public Transform firePosition;

    Transform player;
    float currentFireTime;
    float currentPatternTime;
    bool isStart = true;


    NavMeshAgent smith;

    // 보스 패턴 열거 상수
    public enum BossState
    {
        Idle,
        Pattern1,
        Pattern2,
        Pattern3
    }

    public BossState bossState;

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
                StartPattern1();
                break;
            case BossState.Pattern2:
                StartPattern2();
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
                float random = Random.Range(-10f, 11);

                // firePostion의 각도에 랜덤 값 대입
                firePosition.localEulerAngles = new Vector3(0, random, 0);

                Instantiate(bossAttack, firePosition.position, firePosition.rotation);

                currentFireTime = 0;
            }
        }
        // 커지면 다른 패턴을 실행한다.
        else
        {
            currentPatternTime = 0;
        }
    }

    void StartPattern1()
    {
        if (isStart)
        {
            // 변수 초기화
            currentFireTime = 0;
            currentPatternTime = 0;

            isStart = false;
        }

        Pattern1();
    }


    // 패턴 2) 랜덤 위치에 폭탄을 생성시키고 싶다.
    void Pattern2()
    {
        currentFireTime += Time.deltaTime;
        currentPatternTime += Time.deltaTime;

        if (currentPatternTime <= patternTime)
        {
            if (currentFireTime >= fireDelay)
            {
                // X, Z 값에 랜덤 대입
                float randomX = Random.Range(-40f, 41f);
                float randomZ = Random.Range(-40f, 41f);

                Vector3 fallPos = new Vector3(randomX, 5f, randomZ);

                Instantiate(bossBoom, fallPos, Quaternion.identity);

                currentFireTime = 0;
            }
        }
        else
        {
            currentPatternTime = 0;
        }
    }

    void StartPattern2()
    {
        if (isStart)
        {
            // 변수 초기화
            currentFireTime = 0;
            currentPatternTime = 0;

            isStart = false;
        }

        Pattern2();
    }
}
