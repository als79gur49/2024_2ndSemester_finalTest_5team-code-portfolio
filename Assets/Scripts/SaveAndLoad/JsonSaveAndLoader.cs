using System.IO;
using UnityEngine;

public class JsonSaveAndLoader : MonoBehaviour
{
    private readonly string dataPath;

    public JsonSaveAndLoader(string _dataPath = "PlayerData.Json")
    {
        dataPath = Path.Combine(Application.dataPath, _dataPath); //에셋 파일 안에 존재
    }

    public void SaveData(PlayerData data)
    {
        string json = JsonUtility.ToJson(data); //Json형식으로 변경

        File.WriteAllText(dataPath, json); //(기존 파일 삭제) 새 파일 생성, 자동Close()
        Debug.Log($"{json}내용이 {dataPath}에 저장되었습니다.");
    }

    public PlayerData LoadData()
    {
        if( !File.Exists(dataPath)) //기본 데이터로 반환
        {
            PlayerData newData = new PlayerData();

            Debug.Log($"{newData}이 존재하지 않아 {JsonUtility.ToJson(newData)}초기화 후 {dataPath}에 생성하였습니다.");

            return newData;
        }

        string json = File.ReadAllText(dataPath);

        PlayerData existingData = new PlayerData();
        existingData = JsonUtility.FromJson<PlayerData>(json);

        Debug.Log($"{existingData}데이터 불러왔습니다. {dataPath}에서 불러왔습니다.");

        return existingData;
    }
}