using System.Diagnostics;
using Unity.Burst.Intrinsics;

[System.Serializable]
public class PlayerData
{
    public int stageLevel; //클리어한 스테이지
    public int maxStageLevel; //최대 스테이지
    public StageInfo[] stageInfos;//스테이지별 세부 정보들

    public Settings settings;//사운드 등 세팅

    public PlayerData()
    {
        stageLevel = 0; //클리어한 스테이지
        maxStageLevel = 5;

        stageInfos = new StageInfo[maxStageLevel + 1]; //배열의 크기  시작 인덱스 1부터
        for (int i = 0; i < stageInfos.Length; i++)
        {
            stageInfos[i] = new StageInfo();
            stageInfos[i].Init(StageClearState.NotCleard, 0, $"Stage{i}", "이름 없음", "입력되지 않음");
        }

        if (stageInfos.Length >= 2) //1스테이지 도전상태로 변경
        {
            stageInfos[1].stageClearState = StageClearState.InProgress;
        }

        settings = new Settings();
        settings.Init(0, 0, 0);
    }
}

[System.Serializable]
public class Settings
{    //value: -80 ~ 20
    public int masterVolume; //AudioMixer의 볼륨들
    public int bgmVolume; //모든 볼륨들은 반드시 여러 Volume 중 하나로 출력하기
    public int effectVolume;

    public void Init(int _masterVolume, int _bgmVolume, int _effectVolume)
    {
        masterVolume = _masterVolume;
        bgmVolume = _bgmVolume;
        effectVolume = _effectVolume;
    }
}


public enum StageClearState //json 파일 수정 시 주의사항, json내부에서 enum을 문자열이 아닌 숫자로 읽기에 문자열로 적으면 
{ //매핑 실패로 초기값이 작성됨.
    Error,
    NotCleard, //클리어 X
    InProgress, //도전 중
    Cleard // 클리어 O
}


[System.Serializable]
public class StageInfo
{
    public StageClearState stageClearState; // 에러, 클리어 o, 도전 중, 클리어 x
    public int achievedStars; //획득한 별 개수 0 ~ 3
    public string sceneName; //ex) Stage1, Stage2 ~ Stage10

    public string stageName; //스테이지 이름
    public string storyDetails; //스테이지 스토리 내용

    public void Init(StageClearState _stageClearState,int _achievedStars, string _sceneName, string _stageName, string _storyDetails)
    {
        stageClearState = _stageClearState;
        achievedStars = _achievedStars;
        sceneName = _sceneName;

        stageName = _stageName;
        storyDetails = _storyDetails;
    }
}


