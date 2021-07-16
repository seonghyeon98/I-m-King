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

    // ���� ���� ���� ���
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
        // �⺻ ���´� ��� ����
        bossState = BossState.Idle;

        // �÷��̾��� ��ġ ã��
        player = GameObject.Find("Player").transform;

        // NavMeshAgent ������Ʈ�� �����´�.
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

    // ���� 1) �÷��̾������� �̵��ϸ鼭 patternTime ���� ���� ������ ������ �ϰ� �ʹ�.
    void Pattern1()
    {
        currentFireTime += Time.deltaTime;
        currentPatternTime += Time.deltaTime;

        Vector3 targetPos = new Vector3(player.position.x, transform.position.y, player.position.z);

        // ��� �÷��̾ �Ĵٺ���.
        transform.LookAt(targetPos);

        smith.enabled = true;
        // �÷��̾��� ��ġ�� NavMesh�� �������� �����Ѵ�.
        smith.SetDestination(player.position);

        // ����, currentPatternTime �� patternTime ���� �۴ٸ�
        if (currentPatternTime <= patternTime)
        {
            // ������ ���� ���� ������ �����Ѵ�.
            if (currentFireTime >= fireDelay)
            {
                // firePos
                Vector3 firePos = transform.GetChild(0).position;
                Quaternion fireRot = transform.GetChild(0).rotation;

                currentFireTime = 0;
            }
        }
        // Ŀ���� �ٸ� ������ �����Ѵ�.
        else
        {
            currentPatternTime = 0;
        }
    }
}
