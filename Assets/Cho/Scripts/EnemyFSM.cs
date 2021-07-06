using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    // ����
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
    public float delayTime = 2.0f;
    public GameObject rangedAttack;

    Transform player;
    CharacterController cc;
    Quaternion startRotation;
    float rotSpeed = 0;
    float currentTime = 0;

    void Start()
    {
        // ���� ���´� ��� ����
        eState = EnemyState.Idle;
        eState = 0;

        // Player �� ã�´�.
        player = GameObject.Find("Player").transform;
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        switch (eState)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Move:
                Move();
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

    // ��� ���� �Լ�
    void Idle()
    {
        // ����, �þ� ������ Player�� �ִٸ� �̵� ���·� ��ȯ�Ѵ�.
        // �ʿ� ���: Player�� ������ �Ÿ�, �þ� ����, Player

        // Player�� ������ �Ÿ� ���
        float distance = (player.position - transform.position).magnitude;

        // �þ� ���� �ȿ� Player�� �ִٸ� �̵� ���·� ��ȯ
        if (sightRange >= distance)
        {
            SetMoveState();
        }
    }

    // �̵� ���·� ��ȯ�ϴ� �Լ�
    void SetMoveState()
    {
        // �̵� ���·� ��ȯ
        eState = EnemyState.Move;

        // �̵� �ִϸ��̼� ����

        // ���� ȸ�� ���¸� startRotation���� �����Ѵ�.
        startRotation = transform.rotation;
        // ȸ�� ������ ���� rotRotate�� 0���� �ʱ�ȭ�Ѵ�.
        rotSpeed = 0;
    }

    // �̵� ���� �Լ�
    void Move()
    {
        // ����, �÷��̾���� �Ÿ��� ���� ���� �̳��� �����ߴٸ� ���� ���·� ��ȯ�Ѵ�.
        Vector3 dir = player.position - transform.position;
        float distance = dir.magnitude;

        // �ٰŸ� ������ ���
        if (this.name.Contains("Melee"))
        {
            if (distance <= attackRange)
            {
                eState = EnemyState.MeleeAttack;
                currentTime = 0;

                // ���� �ִϸ��̼� ����

                return;
            }
        }
        // ���Ÿ� ������ ���
        else if (this.name.Contains("Ranged"))
        {
            if (distance <= attackRange)
            {
                eState = EnemyState.RangedAttack;
                currentTime = 0;

                // ���� �ִϸ��̼� ����

                return;
            }
        }

        // �÷��̾� �������� �̵��Ѵ�.
        dir.Normalize();
        cc.Move(dir * moveSpeed * Time.deltaTime);

        // �̵� ������ �ٶ󺸵��� ȸ���Ѵ�.
        Quaternion startRot = startRotation;
        Quaternion endRot = Quaternion.LookRotation(dir);
        rotSpeed += Time.deltaTime * 2f;

        // ���� ������ �̿��Ͽ� ȸ���Ѵ�.
        transform.rotation = Quaternion.Lerp(startRot, endRot, rotSpeed);
    }

    // ���� ���� ���� �Լ�
    void MeleeAttack()
    {
        currentTime += Time.deltaTime;

        // ����, �÷��̾ ���� ���� �̳����
        if (Vector3.Distance(player.position, transform.position) <= attackRange)
        {
            // �� �����̸��� Ÿ���� ü���� ���� ���ݷ¸�ŭ ���ҽ�Ų��.
            if (currentTime >= delayTime)
            {
                currentTime = 0;
            }
        }
        // ���� ���� ���̶��
        else 
        {
            // 1.5�� �ڿ� �̵� ���·� ��ȯ�Ѵ�.
            Invoke("SetMoveState", 1.5f);

            eState = EnemyState.AttackToMove;
        }
    }

    // ���Ÿ� ���� ���� �Լ�
    void RangedAttack()
    {
        currentTime += Time.deltaTime;

        // ����, �÷��̾ ���� ���� ���̶��
        if (Vector3.Distance(player.position, transform.position) >= attackRange)
        {
            Vector3 dir = player.position - transform.position;
            dir.Normalize();

            // ĳ���� �̵�
            cc.Move(dir * moveSpeed * Time.deltaTime);

            // �̵� ������ �ٶ󺸵��� ȸ���Ѵ�.
            Quaternion startRot = startRotation;
            Quaternion endRot = Quaternion.LookRotation(player.position - transform.position);
            rotSpeed += Time.deltaTime * 2f;

            // ���� ������ �̿��Ͽ� ȸ���Ѵ�.
            transform.rotation = Quaternion.Lerp(startRot, endRot, rotSpeed);
        }

        // �� �����̸��� ���Ÿ� ������ ������ �� h, v ���� �������� �������ش�. 
        if (currentTime >= delayTime)
        {
            GameObject go = Instantiate(rangedAttack);
            GameObject firePos = GameObject.Find("firePosition");
            go.transform.position = firePos.transform.position;

            currentTime = 0;
        }
    }

    // ��� ���� �Լ�
    void Die()
    {
        Destroy(this.gameObject);
    }
}