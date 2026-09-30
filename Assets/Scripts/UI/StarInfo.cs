using UnityEngine;

public class StarInfo : MonoBehaviour
{
    [SerializeField]
    private GameObject main;
    [SerializeField]
    private GameObject background;

    public void ActiveMain()
    {
        main.SetActive(true);
    }

    public void DeactiveMain()
    {
        main.SetActive(false);
    }

    public void ActiveBackground()
    {
        background.SetActive(true);
    }

    public void DeactiveBackground()
    {
        background.SetActive(false);
    }
}
