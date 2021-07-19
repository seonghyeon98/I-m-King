using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossFSM : MonoBehaviour
{
    public GameObject bossAttack;
    public GameObject bossBoom;
    public GameObject boomEffect;
    public GameObject bossCircleAttack;
    public float fireDelay = 0.5f;
    public float moveSpeed = 7f;
    public float patternTime = 2f;
    public float stopRange = 15f;
    public Transform firePosition;

    Transform player;
    float currentFireTime;
    float currentPatternTime;
    bool isStart = true;
    int patternRandom;

    NavMeshAgent smith;

    // ���� ���� ���� ���
    public enum BossState
    {
        Pattern1,
        Pattern2,
        Pattern3
    }

    public BossState bossState;

    void Start()
    {
        // �⺻ ���´� ���� 1 ����
        bossState = BossState.Pattern1;

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
            case BossState.Pattern1:
                StartPattern1();
                break;
            case BossState.Pattern2:
                StartPattern2();
                break;
            case BossState.Pattern3:
                StartPattern3();
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
                float random = Random.Range(-10f, 11);

                // firePostion�� ������ ���� �� ����
                firePosition.localEulerAngles = new Vector3(0, random, 0);

                Instantiate(bossAttack, firePosition.position, firePosition.rotation);

                currentFireTime = 0;
            }
        }
        // Ŀ���� �ٸ� ������ �����Ѵ�.
        else
        {
            firePosition.localEulerAngles = new Vector3(0, 0, 0);
            patternRandom = Random.Range(0, 3);
            currentPatternTime = 0;

            if (patternRandom == 0)
            {
                patternRandom = Random.Range(0, 3); 
            }
            else
            {
                bossState = (BossState)(patternRandom);
            }
        }
    }

    void StartPattern1()
    {
        if (isStart)
        {
            // ���� �ʱ�ȭ
            currentFireTime = 0;
            currentPatternTime = 0;

            isStart = false;
        }

        Pattern1();
    }


    // ���� 2) ���� ��ġ�� ��ź�� ������Ű�� �ʹ�.
    void Pattern2()
    {
        currentFireTime += Time.deltaTime;
        currentPatternTime += Time.deltaTime;

        if (currentPatternTime <= patternTime)
        {
            if (currentFireTime >= fireDelay)
            {
                // ��ź ����
                StartCoroutine(BoomCreate());

                currentFireTime = 0;
            }
        }
        else
        {
            patternRandom = Random.Range(0, 3);
            currentPatternTime = 0;

            if (patternRandom == 1)
            {
                patternRandom = Random.Range(0, 3);
            }
            else
            {
                bossState = (BossState)(patternRandom);
            }
        }
    }

    void StartPattern2()
    {
        if (isStart)
        {
            // ���� �ʱ�ȭ
            currentFireTime = 0;
            currentPatternTime = 0;

            isStart = false;
        }

        Pattern2();
    }

    // ���� 3) �÷��̾ �ٶ󺸰� ������ ���� patternTime ���� �������� ������ �ϰ� �ʹ�.
    void Pattern3()
    {
        currentFireTime += Time.deltaTime;
        currentPatternTime += Time.deltaTime;

        Vector3 targetPos = new Vector3(player.position.x, transform.position.y, player.position.z);

        // ��� �÷��̾ �Ĵٺ���.
        transform.LookAt(targetPos);

        if (currentPatternTime <= patternTime)
        {
            if (currentFireTime >= fireDelay)
            {
                Instantiate(bossCircleAttack, firePosition.position, firePosition.rotation);

                currentFireTime = 0;
            }
        }
        else
        {
            patternRandom = Random.Range(0, 3);
            currentPatternTime = 0;

            if (patternRandom == 2)
            {
                patternRandom = Random.Range(0, 3);
            }
            else
            {
                bossState = (BossState)(patternRandom);
            }
        }
    }

    void StartPattern3()
    {
        if (isStart)
        {
            // ���� �ʱ�ȭ
            currentFireTime = 0;
            currentPatternTime = 0;

            isStart = false;
        }

        Pattern3();
    }

    // ��ź ���� �ڷ�ƾ
    IEnumerator BoomCreate()
    {
        // X, Z ���� ���� ����
        float randomX = Random.Range(-40f, 41f);
        float randomZ = Random.Range(-40f, 41f);

        Vector3 fallPos = new Vector3(randomX, 2.5f, randomZ);

        // ȿ�� ����
        GameObject go = Instantiate(boomEffect, fallPos, Quaternion.identity);

        // ȿ�� ���� �� 1�� �ڿ� ��ź ����
        yield return new WaitForSeconds(1f);
        Instantiate(bossBoom, go.transform.position, Quaternion.identity);
    }
}
