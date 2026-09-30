using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // 싱글톤 패턴


    

    private void Awake()
    {
        // 싱글톤 설정
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StageClear()
    {
        DataManager.Instance.UpdateData(); //승리한 경우 해당 정보를 수정 및 저장
        DataManager.Instance.SaveData();

        FindObjectOfType<StageManager>().OpenVictoryPanel();

        SoundManager.Instance.PlayBGMAudio("Success");
    }

    public void StageDefeat()
    {
        //실패는 데이터관련 처리 X
        FindObjectOfType<StageManager>().OpenDefeatPanel();

        SoundManager.Instance.PlayBGMAudio("Defeated");
    }
}
