using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class UpdateHealthText : MonoBehaviour
{
    [SerializeField]
    private UnitStats target;

    private TextMeshProUGUI text;

    public void SetUp(UnitStats target)
    {
        this.target = target;  
    }

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        
    }


    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f); //UnitStats의 currentHP 초기화 부분이 Start에 있어서 나머지 곳에서 Start보다 이후에 작동하게 변경
        if(target == null)
        {
            Destroy(gameObject);
        }
            UpdateHPText(target.currentHealth, target.maxHealth); //text 초기화
            this.target.OnHealthChanged.AddListener(UpdateHPText);
    }


    public void UpdateHPText(int currentHP, int maxHP)
    {
        if(text == null)
        {
            return;
        }

        if(currentHP <= 0)
        {
            Destroy(gameObject);
        }

        text.text = currentHP + " / " + maxHP;
    }
}
