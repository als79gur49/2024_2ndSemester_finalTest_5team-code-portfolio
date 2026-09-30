
using UnityEngine;
using UnityEngine.UI;
public class ChangeImage : MonoBehaviour
{
    [SerializeField]
    private Sprite newSprite;

    public void ChangeSprite()
    {
        if(TryGetComponent<Image>(out Image image))
        {
            image.sprite = newSprite;
        }
    }
}
