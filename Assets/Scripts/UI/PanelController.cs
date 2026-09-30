using UnityEngine;

public class PanelController : MonoBehaviour
{
    //Button 컴포넌트에 붙어서 특정 UI OnOff
    [SerializeField]
    private GameObject selectedPanel;

    private void TogglePanel(bool isActive)
    {
        if (selectedPanel == null)
        {
            Debug.Log("패널이 할당되지 않음.");

            return;
        }

        selectedPanel.SetActive(isActive);
    }

    public void OpenPanel()
    {
        TogglePanel(true);
    }
    public void ClosePanel()
    {
        TogglePanel(false);
    }
}
