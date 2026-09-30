using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
public class StageManager : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent OnWinEvent; //승리 이벤트
    [HideInInspector]
    public UnityEvent OnDefeatEvent; //패배 이벤트

    [SerializeField]
    private GameObject victoryPanel;
    [SerializeField]
    private GameObject defeatedPanel;
    public GameObject VictoryPanel { get; set; }
    public GameObject DefeatedPanel {  get; set; }

    [SerializeField]
    private UnitStats playerTower; //플레이어 타워

    private bool isCleard = false; //
    private int achievedStars = 0;
    private string sceneName;

    public bool IsCleard => isCleard;
    public int AchievedStars => achievedStars;
    public string SceneName => sceneName;


    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f);//가장 늦게 이벤트에 구독

        this.OnWinEvent.AddListener(DeactiveTowerCollision);//타워 무적
        this.OnWinEvent.AddListener(UpdateStageState);//스테이지 상태 체크
        this.OnWinEvent.AddListener(CallGameManager);

        this.OnDefeatEvent.AddListener(DeactiveTowerCollision);
        this.OnDefeatEvent.AddListener(CallGameManager);
    }


    private void DeactiveTowerCollision() //게임 끝나고 타워 피격 없애기
    {
        if(playerTower?.TryGetComponent<BoxCollider2D>(out BoxCollider2D box) ?? false)
        {
            box.enabled = false;
        }
    }

    private void UpdateStageState()
    {
        isCleard = true;

        if(playerTower != null && playerTower.unitType == UnitType.UnitTower)
        {
            float percent = playerTower.currentHealth / playerTower.maxHealth;

            if(percent > 0.6f)
            {
                achievedStars = 3;
            }
            else if(percent > 0.1f)
            {
                achievedStars = 2;
            }
            else if(percent >0f)
            {
                achievedStars = 1;
            }
        }

        sceneName = SceneManager.GetActiveScene().name; //씬 이름의 경우 Stage1, Stage2 ... Stage10형식
    }

    private void CallGameManager()
    {
        if (isCleard)
        {
            GameManager.Instance.StageClear();
        }
        else
        {
            GameManager.Instance.StageDefeat();
        }
    }


    private void OpenUI(GameObject panel) //비활성화 된 UI 활성화
    {
        panel.SetActive(true);
    }

    public void OpenVictoryPanel()
    {
        OpenUI(victoryPanel); //왜 그런지는 정확히 모르겠지만, 변수가 아닌 프로퍼티로 보내면 nullexcep가 자꾸 발생한다.
                              //오브젝트가 비활성화된 상태에서는 프로퍼티에서 Get하면 null을 반환?
        //Debug.Log(victoryPanel.name);//변수로 호출하면 작동하지만
        //Debug.Log(VictoryPanel.name);//프로퍼티로 호출하면 nullexception이 발생한다.
    }
    public void OpenDefeatPanel()
    {
        OpenUI(defeatedPanel);
    }
}
