using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPanel : MonoBehaviour
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

    private void OnEnable()
    {
        Time.timeScale = 0f;
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
}
