using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class StagePanel : MonoBehaviour
{
    /// <summary>
    /// 클리어 O: 별, 이미지, 텍스트 정상 출력
    /// 도전 중: 별, 이미지, 텍스트 정상 출력
    /// 클리어 X: 별 X, 이미지 약간 흐릿하게, 텍스트 X
    /// </summary>
    [SerializeField]
    private int stageLevel; //스테이지 레벨 ex) 1, 2, 3, 4, 5

    [SerializeField]
    private StarsController starController;
    [SerializeField]
    private Image stageImage;
    [SerializeField]
    private TextMeshProUGUI stageName;
    [SerializeField]
    private Button stageButton;

    private void Awake()
    {
        Debug.Log(JsonUtility.ToJson(DataManager.Instance.PlayerData));
        StageInfo currentStageInfo = DataManager.Instance.PlayerData.stageInfos[stageLevel];

        switch (currentStageInfo.stageClearState)
        {
            case StageClearState.NotCleard:
                Color targetColor = stageImage?.color ?? Color.clear;
                targetColor.a = 0.5f;
                stageImage.color = targetColor;

                starController.Init(false);
                stageName.text = " ";

                stageButton.interactable = false;

                break;
            case StageClearState.InProgress:
                starController.Init(true, currentStageInfo.achievedStars);
                //stageName.text = currentStageInfo.stageName;
                stageName.text = " ";
                break;
            case StageClearState.Cleard:
                starController.Init(true, currentStageInfo.achievedStars);
                //stageName.text = currentStageInfo.stageName;
                stageName.text = " ";
                break;
        } 
    }
}
