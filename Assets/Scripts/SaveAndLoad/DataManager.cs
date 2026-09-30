using System.IO;
using UnityEngine;
using System.Text;
using System.Text.RegularExpressions;

[RequireComponent(typeof(JsonSaveAndLoader))]
public class DataManager : MonoBehaviour
{
    private static DataManager instance;
    public static DataManager Instance
    {
        get
        {
            if (instance == null) //Awake이전 호출 시, 초기화
            {
                instance = FindObjectOfType<DataManager>();

                if (instance == null)
                {
                    GameObject obj = new GameObject("DataManager");
                    instance = obj.AddComponent<DataManager>();

                    DontDestroyOnLoad(obj);
                }
            }

            return instance;
        }
    }


    private JsonSaveAndLoader saveAndLoader; // Json 읽기 쓰기 클래스
    private PlayerData playerData;  //데이터

    public PlayerData PlayerData //TODO: 시간 되면 Wrapper클래스처럼 외부 노출 제어해보기
    {
        get { return playerData; }
        set { playerData = value; }
    }



    private void Awake() //싱글턴 패턴
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);

            return;
        }

        instance = this;

        DontDestroyOnLoad(this.gameObject);//싱글턴
        
        saveAndLoader = new JsonSaveAndLoader(); //초기화, 기본 PlayerData.json
        //최초 초기화
        LoadData();
    }

    public void LoadData()
    {
        playerData = saveAndLoader.LoadData();
    }

    public void SaveData()
    {
        saveAndLoader.SaveData(playerData);
    }

    public void UpdateData()
    {
        StageManager stageManager = FindObjectOfType<StageManager>();
        if(stageManager != null)
        {
            string pattern = @"^([A-Za-z]+)(\d+)$";////문자열과 숫자를 분리 ex) Stage1 -> Stage, 1
            if ( ! Regex.IsMatch(stageManager.SceneName, pattern))
            {
                Debug.Log($"{stageManager.SceneName} 씬 이름이 {pattern}형식을 따르지 않습니다");
                return;
            }

            if( ! stageManager.IsCleard)
            {
                //바꿀데이터가 데이터가 없기에 반환
                return;
            }

            
            Match match = Regex.Match(stageManager.SceneName, pattern); //문자열과 숫자를 분리 ex) Stage1 -> Stage, 1
            int stageLevel = int.Parse(match.Groups[2].Value); // 숫자부분을 int로 변경

            //클리어한 스테이지 변경
            if (stageLevel >= PlayerData.stageLevel)
            {
                Debug.Log($"클리어한 최대 스테이지를 {PlayerData.stageLevel} -> {stageLevel}로 변경");
                PlayerData.stageLevel = stageLevel;
            }

            //stageInfos 세부 정보 변경
            
            PlayerData.stageInfos[stageLevel].stageClearState = StageClearState.Cleard;
            Debug.Log($"{PlayerData.stageInfos[stageLevel].achievedStars} -> {stageManager.AchievedStars}로 별 개수 변경");
            PlayerData.stageInfos[stageLevel].achievedStars = stageManager.AchievedStars;

            for(int i = 1; i <= PlayerData.stageLevel; i++)
            {
                PlayerData.stageInfos[i].stageClearState = StageClearState.Cleard;
            }
            if(PlayerData.stageLevel+ 1 <= PlayerData.maxStageLevel)
            {
                PlayerData.stageInfos[PlayerData.stageLevel + 1].stageClearState = StageClearState.InProgress;
            }
        }
    }
}
