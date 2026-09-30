using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMove : MonoBehaviour
{
    public float moveSpeed = 1f; // 이동 속도
    private Transform target; // 공격할 적
    private bool isAttack = false;
    public bool IsAttack { get; set; }
    Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
    // Update is called once per frame
    private void Update()
    {
        if (!isAttack)
        {
            Move(); // 공격 상태가 아니면 이동
            anim.SetBool("isRun", true);
        }
        else
        {
            anim.SetBool("isAttack", true); // 공격 상태일때 애니메이션 출력
            anim.SetBool("isRun", false);
        }
    }

    // 플레이어 유닛 이동
    public void Move()
    {
        // 공격할 상대가 없으면 앞으로 이동
        if (target == null)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
    }

    // 충돌 유지
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            isAttack = true;
            if (!isAttack)
            {
                anim.SetBool("isAttack", true);
            }
        }
    }


    // 충돌이 벗어날 때
    private void OnTriggerExit2D(Collider2D collision)
    {
        isAttack = false;
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("OFF");
            anim.SetBool("isAttack", false);
        }
    }
}
