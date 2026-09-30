using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class ButtonClickLimit : MonoBehaviour
{
    //interact를 비활성화 하고 싶은 버튼 컴포넌트 붙히고, 클릭할 버튼 이벤트에 넣기
    [SerializeField]
    private Button button;
    
    public void RestrictButtonClick2(float time)
    {
        StartCoroutine(Restrict(time));
    }
    private IEnumerator Restrict(float time)
    {
        button.interactable = false;

        yield return new WaitForSeconds(time);

        button.interactable = true;
    }
}
