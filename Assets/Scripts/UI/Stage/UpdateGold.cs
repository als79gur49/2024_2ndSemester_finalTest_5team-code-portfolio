using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGold : MonoBehaviour
{
    [SerializeField]
    private Image goidImage; //골드 이미지 -> ex)일정 수치 이상이면 이미지를 바꾸는 등의 활용
    [SerializeField]
    private TextMeshProUGUI goldText; //골드 숫자

    public void UpdateGoldHUD(int prev, int curr)
    {
        goldText.text = curr + "G";
    }
}
