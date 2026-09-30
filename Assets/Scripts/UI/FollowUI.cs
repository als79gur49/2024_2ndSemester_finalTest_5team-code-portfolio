using TMPro;
using UnityEngine;

public class FollowUI : MonoBehaviour
{
    //외부에서 SetUp하는 구조
    [SerializeField]
    private Transform target;

    private RectTransform rectTransform;
    private TextMeshProUGUI text;

    private Vector3 screenPoint;
    public void SetUp(Transform target)
    {
        this.target = target;
    }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
        }

        screenPoint = Camera.main.WorldToScreenPoint(target.position);

        rectTransform.position = screenPoint;
    }
}
