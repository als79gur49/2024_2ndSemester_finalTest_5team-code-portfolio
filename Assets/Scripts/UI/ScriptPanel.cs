using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScriptPanel : MonoBehaviour
{
    [SerializeField]
    private int stageLevel; //스테이지 레벨 ex) 1, 2, 3, 4, 5

    [SerializeField]
    private TextMeshProUGUI textName;
    [SerializeField]
    private TextMeshProUGUI textDetail;

    [SerializeField]
    private SceneLoader startButtonSceneLoader;

    private void Awake()
    {
        StageInfo currentStageInfo = DataManager.Instance.PlayerData.stageInfos[stageLevel];
        
        startButtonSceneLoader.SceneToLoad = currentStageInfo.sceneName;
        textName.text = currentStageInfo.stageName;
        textDetail.text = currentStageInfo.storyDetails;
    }
}
