using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitAttackTiming : MonoBehaviour
{
    [SerializeField]
    public string targetTag = "Enemy";

    private GameObject target;
    private List<GameObject> targetLists;
    private UnitStats stat;

    private void Awake()
    {
        stat = GetComponentInParent<UnitStats>();
        //stat = GetComponent<UnitStats>();
        targetLists = new List<GameObject>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( ! collision.CompareTag(targetTag)) //목표만 검색
        {
            return;
        }

        if( ! targetLists.Contains(collision.gameObject) )// 예비목표들을 리스트에 저장
        {
            targetLists.Add(collision.gameObject);
        }

        if (target == null) // 목표가 없으면 새로 지정
        {
            target = collision.gameObject;

            Debug.Log("NewTarget");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (targetLists.Contains(collision.gameObject))
        {
            targetLists.Remove(collision.gameObject);
        }
    }

    public void Attack()
    {
        if (target == null || target.GetComponent<BoxCollider2D>() != null) // target이 boxCollider가지고 있을 경우에만 공격 -> Die애니 상태에서 Box꺼두어서
        {
            targetLists.RemoveAll(t => (t == null || t.GetComponent<BoxCollider2D>() == null));

            target = targetLists.FirstOrDefault();
        }

        if(target == null)
        {
            return;
        }

        if(target.TryGetComponent<UnitStats>(out UnitStats targetStat))
        {
            targetStat.TakeDamage(stat.attackDamage);
        }
    }
}
