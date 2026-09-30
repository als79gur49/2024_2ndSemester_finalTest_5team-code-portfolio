using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UnitUI : MonoBehaviour
{
    [Header("게임오브젝트 프리팹")]
    [SerializeField]
    public UnitStats unitObject;
    [SerializeField]
    private int spendGold;

    [Header("캔버스 관련")]
    [SerializeField]
    private GameObject targetCanvas;
    [SerializeField]
    private GameObject healthText;    

    [Header("내부 배치 UI")]
    [SerializeField]
    private TextMeshProUGUI characterName; //캐릭터 이름
    [SerializeField]
    private Image characterImage; //캐릭터 이미지
    [SerializeField]
    private Button spawnButton; //소환 버튼
    [SerializeField]
    private Image cooldownImage; //쿨다운 나타낼 이미지 or 텍스트
    [SerializeField]
    private TextMeshProUGUI spawnSpendGold;
    //스포너 스크립트

    //쿨다운 확인 -> 골드 확인 -> 최대 소환 수 확인 -> 소환
    private bool isCooldownReady = true;
    private float characterCooldown;

    private Coroutine cooldownCoroutine; //현재 실행 중인 코루틴, stopCoroutine은 매개변수 있을 경우 작동하지 않는 듯

    private GoldSystem goldSystem;
    private UnitSpawn gameManager;

    private UnitMove unitMove;

    private void Awake()
    {
        if(characterName != null)
        {
            characterName.text = unitObject.unitName;
        }
        if(characterImage != null)
        {
            characterImage.sprite = unitObject.unitImage;
        }
        if(spawnSpendGold != null)
        {
            spawnSpendGold.text = spendGold + "G";
        }
        characterCooldown = unitObject.unitCooldown;
        

        goldSystem = FindObjectOfType<GoldSystem>();
        gameManager = FindAnyObjectByType<UnitSpawn>();
    }

    public void Spawn()
    {
        if(isCooldownReady) //쿨다운 확인, 값 변경은 UpdateHUD에 붙어있음
        {
            if(goldSystem.currentGold >= spendGold) //골드 확인
            {
                if(true) // 최대 소환 수 확인
                {
                    if(cooldownCoroutine != null) //이전 코루틴 중지
                    {
                        StopCoroutine(cooldownCoroutine);
                    }
                    cooldownCoroutine = StartCoroutine(UpdateHUD(characterCooldown, cooldownImage)); //쿨다운 동안 이미지 + 쿨다운 OnOff

                    UnitStats clone = Instantiate(unitObject, gameManager.PlayerspawnPoint);
                    goldSystem.SpendGold(spendGold);

                    //UnitMove unitmove = clone.GetComponent<UnitMove>();

                    if (targetCanvas != null && healthText != null)
                    {
                        GameObject HPText = Instantiate(healthText);
                        HPText.transform.SetParent(targetCanvas.transform);
                        HPText.GetComponent<FollowUI>().SetUp(clone.HUDPoint);
                        HPText.GetComponent<UpdateHealthText>().SetUp(clone);
                    }

                    Debug.Log("Spawn");
                
                }
                else
                {
                    //더이상 소환 불가능 하다는 UI
                    PopupMessage.Instance.PopUpMessege("더이상 소환을 할 수 없습니다.", Color.yellow, 5, new Vector2(5, 25));
                }
            }
            else
            {
                //골드 부족하다는 UI
                PopupMessage.Instance.PopUpMessege("소환에 필요한 골드가 부족합니다.", Color.yellow, 5, new Vector2(5, 25));
            }
        }
        else
        {   
            //쿨다운 남았다는 UI
            PopupMessage.Instance.PopUpMessege("쿨다운이 남아 있습니다.", Color.yellow, 5, new Vector2(5, 25));
        }
    }

    private IEnumerator UpdateHUD(float time, Image image) //time초 동안 fill
    {
        isCooldownReady = false;
        image.fillAmount = 0;
        image.enabled = true;

        float percent = 0;
        while (percent < 1)
        {
            yield return null;

            image.fillAmount = (1 - percent); // 이미지 cooldown 예시 
            //testText.text = percent * time + "초"; // text cooldown 예시

            percent += Time.deltaTime / time;
        }

        isCooldownReady = true;
        image.enabled = false;
    }
}

