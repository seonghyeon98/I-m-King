using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�÷��̾ ������� �Է¿� ���� �Է��� �������� �̵��ϰ� �ʹ�
//�̵��� �� �� ���⿡ �˸°� ȸ���ϰ� �ʹ�
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

        Vector3 dir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        dir = transform.TransformDirection(dir.normalized);

        animator.SetFloat("VerticalMove", Input.GetAxisRaw("Vertical"));
        animator.SetFloat("HorizontalMove", Input.GetAxisRaw("Horizontal"));

        charactorController.Move(dir * speed * Time.deltaTime);
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
