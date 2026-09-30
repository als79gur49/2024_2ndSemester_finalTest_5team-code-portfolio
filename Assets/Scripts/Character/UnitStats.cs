using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
public enum UnitType
{
    UnitTower,
    Unit,
    Boss,
    MonsterUnit,
    Monstermansion,
    Monstercastlegate
}

[System.Serializable]
public class UnitStats : MonoBehaviour
{
    public UnitType unitType;
    public int maxHealth; // 최대 체력
    public int attackDamage; // 공격력
    public float attackCooldown; // 공격 쿨타임
    public float attackRange; // 공격 범위
    public LayerMask enemyLayer;
    private bool isDead = false;

    public int goldReward; // 적 유닛 처치 시 지급할 골드
    private GoldSystem goldSystem;
    

    public int currentHealth; // 현재 체력

    public string unitName; //유닛 이름
    public Sprite unitImage; // Button에 띄어둘 유닛 이미지
    public float unitCooldown; // 유닛 재소환 시간

    public GameObject stageClearPanel; // 스테이지 클리어 패널

   
    public Transform HUDPoint;
    public UnityEvent<int, int> OnHealthChanged; // current, max

    public Animator anim;

    private UnitUI unitUI;
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        unitUI = FindObjectOfType<UnitUI>(); // UnitUI 스크립트 찾기
    }
    void Start()
    {
        currentHealth = maxHealth; // 초기 체력을 최대 체력으로 설정
        goldSystem = FindObjectOfType<GoldSystem>();
    }
    public void TakeDamage(int damage)
    {
            currentHealth -= damage;
            Debug.Log($"{gameObject.name} 체력: {currentHealth}");

        OnHealthChanged?.Invoke(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        if (isDead) return; // 이미 죽었으면 리턴
        isDead = true;

        if(CompareTag("Enemy"))
        {
            if (goldSystem != null)
            {
                //적 유닛 사망 시 골드 지급
                if(unitType == UnitType.MonsterUnit)
                {
                    goldSystem.AddGold(goldReward);
                    Debug.Log($"{goldSystem.currentGold}");
                }
                /*if (unitType == UnitType.Boss)
                {
                    if (!anim.GetCurrentAnimatorStateInfo(0).IsName("isDie"))
                    {
                        Debug.Log("보스 몬스터 애니메이션 출력");
                        anim.SetTrigger("isDie");
                        StartCoroutine(WaitForDieAnimation());
                        // 씬이동
                    }
                }*/
            }
        }
        if(true)
        {
            if (anim != null && !anim.GetCurrentAnimatorStateInfo(0).IsName("isDie"))
            {
                anim.SetTrigger("isDie");
                if (TryGetComponent<BoxCollider2D>(out BoxCollider2D box)) //엄연히 죽은 상태이지만, 삭제되기 전이라 충돌을 계속 진행 중
                {
                    box.enabled = false;
                }
                if(TryGetComponent<UnitMove>(out UnitMove movePlayer))
                {
                    movePlayer.IsAttack = false;
                }
                if(TryGetComponent<MonsterUnitMove>(out MonsterUnitMove moveMonster))
                {
                    moveMonster.IsAttack = false;
                }
                StartCoroutine(WaitForDieAnimation());
            }
        }
        if ((unitType == UnitType.Boss || unitType == UnitType.Monstermansion )&& 
            currentHealth <= 0)
        {
            FindObjectOfType<StageManager>()?.OnWinEvent.Invoke();
        }

        if(unitType == UnitType.UnitTower && currentHealth <= 0)
        {
            FindObjectOfType<StageManager>()?.OnDefeatEvent.Invoke();
        }

        if (unitType == UnitType.Monstermansion || unitType == UnitType.Monstercastlegate)
        {
            Destroy(gameObject);
        }

    }
    private IEnumerator WaitForDieAnimation()
    {
        // 애니메이션 상태 정보 얻기
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);


        // "isDie" 애니메이션이 끝날 때까지 대기 (애니메이션 길이만큼 대기)
        yield return new WaitForSeconds(stateInfo.length);

        // 애니메이션이 끝난 후 오브젝트 삭제
        Destroy(gameObject);
    }

    // 공격 범위를 변경하는 함수
    public void SetAttackRange(float newRange)
    {
        attackRange = newRange;
    }
}
