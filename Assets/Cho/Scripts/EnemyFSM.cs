using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
    public float stopRange = 5.0f;
    public float delayTime = 2.0f;
    public float attackDamage = 10.0f;
    public GameObject rangedAttack;
    public Transform firePosition;

    Transform player;
    //CharacterController cc;
    //Quaternion startRotation;
    //float rotSpeed = 0;
    float currentTime = 0;
    NavMeshAgent smith;

    void Start()
    {
        // ���� ���´� ��� ����
        eState = EnemyState.Idle;
        eState = 0;

        // Player �� ã�´�.
        player = GameObject.Find("Player").transform;
        //cc = GetComponent<CharacterController>();

        // NavMeshAgent ������Ʈ�� �����´�.
        smith = GetComponent<NavMeshAgent>();
        smith.speed = moveSpeed;
        smith.acceleration = 20.0f;
        smith.stoppingDistance = stopRange;
    }

    void Update()
    {
        if (player != null)
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
        //startRotation = transform.rotation;
        // ȸ�� ������ ���� rotRotate�� 0���� �ʱ�ȭ�Ѵ�.
        //rotSpeed = 0;
    }

    // �̵� ���� �Լ�
    //void Move()
    //{
    //    // ����, �÷��̾���� �Ÿ��� ���� ���� �̳��� �����ߴٸ� ���� ���·� ��ȯ�Ѵ�.
    //    Vector3 dir = player.position - transform.position;
    //    float distance = dir.magnitude;

    //    // �ٰŸ� ������ ���
    //    if (this.name.Contains("Melee"))
    //    {
    //        if (distance <= attackRange)
    //        {
    //            eState = EnemyState.MeleeAttack;
    //            currentTime = 0;

    //            // ���� �ִϸ��̼� ����

    //            return;
    //        }
    //    }
    //    // ���Ÿ� ������ ���
    //    else if (this.name.Contains("Ranged"))
    //    {
    //        if (distance <= attackRange)
    //        {
    //            eState = EnemyState.RangedAttack;
    //            currentTime = 0;

    //            // ���� �ִϸ��̼� ����

    //            return;
    //        }
    //    }

    //    // �÷��̾� �������� �̵��Ѵ�.
    //    dir.Normalize();
    //    cc.Move(dir * moveSpeed * Time.deltaTime);

    //    // �̵� ������ �ٶ󺸵��� ȸ���Ѵ�.
    //    Quaternion startRot = startRotation;
    //    Quaternion endRot = Quaternion.LookRotation(dir);
    //    rotSpeed += Time.deltaTime * 2f;

    //    // ���� ������ �̿��Ͽ� ȸ���Ѵ�.
    //    transform.rotation = Quaternion.Lerp(startRot, endRot, rotSpeed);
    //}

    void Move2()
    {
        smith.enabled = true;
        // �÷��̾��� ��ġ�� NavMesh�� �������� �����Ѵ�.
        smith.SetDestination(player.position);
        smith.isStopped = false;

        float dist = Vector3.Distance(player.position, transform.position);

        if (this.name.Contains("Melee"))
        {
            if (dist <= attackRange)
            {
                eState = EnemyState.MeleeAttack;

                // ���� �ִϸ��̼� ����

                smith.isStopped = true;
            }
        }

        if (this.name.Contains("Ranged"))
        {
            if (dist <= attackRange)
            {
                eState = EnemyState.RangedAttack;

                // ���� �ִϸ��̼� ����

            }
        }
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
                HPComponent hpComponent = player.GetComponent<HPComponent>();
                if (hpComponent)
                {
                    hpComponent.CurrentHP -= attackDamage;
                }
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

        Vector3 targetPos = new Vector3(player.position.x, transform.position.y, player.position.z);

        // ��� �÷��̾ �Ĵٺ���.
        transform.LookAt(targetPos);

        smith.enabled = true;
        // �÷��̾��� ��ġ�� NavMesh�� �������� �����Ѵ�.
        smith.SetDestination(player.position);

        // �� �����̸��� ���Ÿ� ������ �����Ѵ�. 
        if (currentTime >= delayTime)
        {
            // ���� ����
            Instantiate(rangedAttack, firePosition.position, firePosition.rotation);

            currentTime = 0;
        }
    }

    // ��� ���� �Լ�
    void Die()
    {
        Destroy(this.gameObject);
    }
}