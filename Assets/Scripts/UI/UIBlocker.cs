using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBlocker : MonoBehaviour
{
    /// <summary>
    /// UIBlocker는 stack을 가짐, UI창이 켜지면 해당 UI Push, 꺼지면 Pop형태
    /// UIBlocker는 stack의 Peek의 자식 오브젝트에 위치
    /// Peek 존재하지 않으면 끄기
    /// 
    /// 특정 UI창을 열거나, 닫는 버튼 이벤트에 Open, CloseUI()함수를 넣어줘야 작동함.
    /// </summary>
    /// 
    [SerializeField]
    private GameObject blocker;
    private Stack<GameObject> uiStack = new Stack<GameObject>();

    public void OpenUI(GameObject UI)
    {
        uiStack.Push(UI);

        ChangeBlockerPosition();
    }
    public void CloseUI(GameObject UI)
    {
        if(uiStack.Count > 0 && uiStack.Peek() == UI)
        {
            uiStack.Pop();
        }

        ChangeBlockerPosition();
    }

    private void ChangeBlockerPosition()
    {
        if (blocker == null)
        {
            //blocker없을 경우 새로 추가

            return;
        }

        blocker.SetActive(uiStack.Count > 0); //열려있는 UI가 없을 경우 비활성화

        if(uiStack.TryPeek(out GameObject parentUI)) //제일 위의 UI의 자식으로 Blocker 배치
        {
            blocker.transform.SetParent(parentUI.transform, true); //부모 변경 및 현재 위치 움직이지 않음
            blocker.transform.SetSiblingIndex(0); //자식 인덱스 중에서 젤 위로 옮김. 다른 UI가리지 않게 하기
        }
    }
}
