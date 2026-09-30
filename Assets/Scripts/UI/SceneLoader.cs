using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //Button 컴포넌트에 붙어서 특정 Scene로드
    [SerializeField]
    private string sceneToLoad; //직접 인스펙터에서 입력
    
    //외부or 부모에서 따로 지정
    public string SceneToLoad { get=>sceneToLoad; set=>sceneToLoad = value; } 

    public void LoadSceneByName()
    {
        //TODO: 찾지 못했을 경우 로그 띄우기
        SceneManager.LoadScene(sceneToLoad);

        Debug.Log($"{sceneToLoad}를 로드한다");
    }
}
