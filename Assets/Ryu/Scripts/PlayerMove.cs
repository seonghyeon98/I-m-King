using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//플레이어가 사용자의 입력에 따라 입력한 방향으로 이동하고 싶다
//이동할 때 그 방향에 알맞게 회전하고 싶다
//f)
//	speed

//m)
//	Move()
//	LookAtMousePos()
public class PlayerMove : MonoBehaviour
{
    CharacterController charactorController;
    Animator animator;
    [SerializeField] float speed;

    private void Awake()
    {
        charactorController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        LookAtMousePos();

        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        Vector3 localDir = transform.TransformDirection(moveDir);

        animator.SetFloat("VerticalMove", localDir.z);
        animator.SetFloat("HorizontalMove", localDir.x);

        charactorController.Move(moveDir * speed * Time.deltaTime);
    }

    void LookAtMousePos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            Vector3 point = hit.point - transform.position;
            point.y = 0;
            transform.LookAt(transform.position + point);
        }        
    }
}
