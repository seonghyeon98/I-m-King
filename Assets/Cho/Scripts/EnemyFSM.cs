using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{
    // 열거
    public enum EnemyState
    {
        Idle,
        Move,
        MeleeAttack,
        RangedAttack,
        AttackToMove,
        Damaged,
        Die
    }

    public EnemyState eState;

    public float sightRange = 10.0f;
    public float moveSpeed = 7.0f;
    public float attackRange = 2.0f;
    public float stopRange = 5.0f;
    public float delayTime = 2.0f;
    public GameObject rangedAttack;

    Transform player;
    //CharacterController cc;
    //Quaternion startRotation;
    //float rotSpeed = 0;
    float currentTime = 0;
    NavMeshAgent smith;

    void Start()
    {
        // 최초 상태는 대기 상태
        eState = EnemyState.Idle;
        eState = 0;

        // Player 를 찾는다.
        player = GameObject.Find("Player").transform;
        //cc = GetComponent<CharacterController>();

        // NavMeshAgent 컴포넌트를 가져온다.
        smith = GetComponent<NavMeshAgent>();
        smith.speed = moveSpeed;
        smith.acceleration = 20.0f;
        smith.stoppingDistance = stopRange;
    }

    void Update()
    {
        switch (eState)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Move:
                Move2();
                break;
            case EnemyState.MeleeAttack:
                MeleeAttack();
                break;
            case EnemyState.RangedAttack:
                RangedAttack();
                break;
            case EnemyState.Damaged:
                break;
            case EnemyState.Die:
                Die();
                break;
            default:
                break;
        }
    }

    // 대기 상태 함수
    void Idle()
    {
        // 만약, 시야 범위에 Player가 있다면 이동 상태로 전환한다.
        // 필요 요소: Player와 나와의 거리, 시야 범위, Player

        // Player와 나와의 거리 계산
        float distance = (player.position - transform.position).magnitude;

        // 시야 범위 안에 Player가 있다면 이동 상태로 전환
        if (sightRange >= distance)
        {
            SetMoveState();
        }
    }

    // 이동 상태로 전환하는 함수
    void SetMoveState()
    {
        // 이동 상태로 전환
        eState = EnemyState.Move;

        // 이동 애니메이션 실행

        // 현재 회전 상태를 startRotation으로 저장한다.
        //startRotation = transform.rotation;
        // 회전 보간을 위한 rotRotate도 0으로 초기화한다.
        //rotSpeed = 0;
    }

    // 이동 상태 함수
    //void Move()
    //{
    //    // 만약, 플레이어와의 거리가 공격 범위 이내로 접근했다면 공격 상태로 전환한다.
    //    Vector3 dir = player.position - transform.position;
    //    float distance = dir.magnitude;

    //    // 근거리 유닛일 경우
    //    if (this.name.Contains("Melee"))
    //    {
    //        if (distance <= attackRange)
    //        {
    //            eState = EnemyState.MeleeAttack;
    //            currentTime = 0;

    //            // 공격 애니메이션 실행

    //            return;
    //        }
    //    }
    //    // 원거리 유닛일 경우
    //    else if (this.name.Contains("Ranged"))
    //    {
    //        if (distance <= attackRange)
    //        {
    //            eState = EnemyState.RangedAttack;
    //            currentTime = 0;

    //            // 공격 애니메이션 실행

    //            return;
    //        }
    //    }

    //    // 플레이어 방향으로 이동한다.
    //    dir.Normalize();
    //    cc.Move(dir * moveSpeed * Time.deltaTime);

    //    // 이동 방향을 바라보도록 회전한다.
    //    Quaternion startRot = startRotation;
    //    Quaternion endRot = Quaternion.LookRotation(dir);
    //    rotSpeed += Time.deltaTime * 2f;

    //    // 선형 보간을 이용하여 회전한다.
    //    transform.rotation = Quaternion.Lerp(startRot, endRot, rotSpeed);
    //}

    void Move2()
    {
        smith.enabled = true;
        // 플레이어의 위치를 NavMesh의 목적지로 설정한다.
        smith.SetDestination(player.position);
        smith.isStopped = false;

        float dist = Vector3.Distance(player.position, transform.position);

        if (this.name.Contains("Melee"))
        {
            if (dist <= attackRange)
            {
                eState = EnemyState.MeleeAttack;

                // 공격 애니메이션 실행

                smith.isStopped = true;
            }
        }

        if (this.name.Contains("Ranged"))
        {
            if (dist <= attackRange)
            {
                eState = EnemyState.RangedAttack;

                // 공격 애니메이션 실행

                smith.isStopped = true;
            }
        }
    }

    // 근접 공격 상태 함수
    void MeleeAttack()
    {
        currentTime += Time.deltaTime;

        // 만약, 플레이어가 공격 범위 이내라면
        if (Vector3.Distance(player.position, transform.position) <= attackRange)
        {
            // 매 딜레이마다 타겟의 체력을 나의 공격력만큼 감소시킨다.
            if (currentTime >= delayTime)
            {
                currentTime = 0;
            }
        }
        // 공격 범위 밖이라면
        else
        {
            // 1.5초 뒤에 이동 상태로 전환한다.
            Invoke("SetMoveState", 1.5f);

            eState = EnemyState.AttackToMove;
        }
    }

    // 원거리 공격 상태 함수
    void RangedAttack()
    {
        currentTime += Time.deltaTime;

        Vector3 targetPos = new Vector3(player.position.x, transform.position.y, player.position.z);

        // 계속 플레이어를 쳐다본다.
        transform.LookAt(targetPos);

        smith.enabled = true;
        // 플레이어의 위치를 NavMesh의 목적지로 설정한다.
        smith.SetDestination(player.position);
        smith.isStopped = false;

        // 매 딜레이마다 원거리 공격을 실행한다. 
        if (currentTime >= delayTime)
        {
            GameObject firePos = GameObject.Find("firePosition");
            // 공격 실행
            Instantiate(rangedAttack, firePos.transform.position, firePos.transform.rotation);

            currentTime = 0;
        }
    }

    // 사망 상태 함수
    void Die()
    {
        Destroy(this.gameObject);
    }
}