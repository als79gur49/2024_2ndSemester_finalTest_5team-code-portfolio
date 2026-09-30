using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.SceneManagement;

public class PopupMessage : MonoBehaviour
{   
    //targetCanvas의 경우 onSceneLoad를 통해서 TargetCanvas라는 Tag를 Find

    //에러 or 획득 등 팝업 text 띄우는 용도
    //텍스트 창이 생기고 특정 방향으로 이동하다 시간이 지나면 삭제되는 텍스트
    [SerializeField]
    private GameObject popUpText; //tmp를 가지는 객체
    [SerializeField]
    private GameObject targetCanvas; //띄워질 캔버스

    private static PopupMessage instance;
    public static PopupMessage Instance
    {
        get
        {
            if (instance == null) //Awake이전 호출 시, 초기화
            {
                instance = FindObjectOfType<PopupMessage>();

                if (instance == null)
                {
                    GameObject obj = new GameObject("PopupMessage");
                    instance = obj.AddComponent<PopupMessage>();

                    DontDestroyOnLoad(obj);
                }
            }

            return instance;
        }
    }

    private void Awake() //싱글턴 패턴
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);

            return;
        }

        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }
    //ex) PopUpMessege("경고 메시지 띄우는 메시지에 대한 테스트 메시지", Color.white, 10, new Vector2(5,20));
    //띄울 메시지, 메시지의 색, 띄우는 시간, 이동 방향+속도
    public void PopUpMessege(string messege, Color color, float time, Vector2 speed)
    {
        GameObject message = Instantiate(popUpText, targetCanvas.transform);

        if(message.TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI messageText))
        {
            messageText.text = messege;
            messageText.color = color;
        }

        StartCoroutine(MoveAndDestroy(message.GetComponent<RectTransform>(), time, speed));
    }

    private IEnumerator MoveAndDestroy(RectTransform rectTransform, float time, Vector2 speed)
    {
        float percent = 0;
        while(percent < 1)
        {
            yield return null;

            rectTransform.position += (Vector3)(speed * Time.deltaTime);

            percent += Time.deltaTime / time;
        }

        Destroy(rectTransform.gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(targetCanvas == null)
        {
            targetCanvas = GameObject.FindGameObjectWithTag("TargetCanvas");
        }
    }

}
