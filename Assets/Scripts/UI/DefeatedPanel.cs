using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DefeatedPanel : MonoBehaviour
{
    [SerializeField]
    private int stageLevel; //스테이지 레벨 ex) 1, 2, 3, 4, 5

    [SerializeField]
    private SceneLoader retryButtonSceneLoader;

    private void Awake()
    {
        StageInfo currentStageInfo = DataManager.Instance.PlayerData.stageInfos[stageLevel];

        retryButtonSceneLoader.SceneToLoad = currentStageInfo.sceneName;
    }
}
