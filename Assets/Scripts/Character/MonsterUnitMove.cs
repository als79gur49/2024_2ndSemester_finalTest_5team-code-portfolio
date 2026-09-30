using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterUnitMove : MonoBehaviour
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
    void Update()
    {
        if (!isAttack)
        {
            Move();
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
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //isAttack = true;
        if (collision.CompareTag("Player"))
        {
            Debug.Log("AttOn");
            isAttack = true;
            if (!isAttack)
            {
                anim.SetBool("isAttack", true);
            }
        }
            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isAttack = false;
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("isAttack", false);
        }
            
    }
}
