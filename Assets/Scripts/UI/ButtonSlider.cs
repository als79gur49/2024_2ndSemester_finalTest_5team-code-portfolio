using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonSlider : MonoBehaviour
{
    [SerializeField]
    private Sprite offSprite;
    [SerializeField]
    private Sprite onSprite;

    private Button button;
    private Image image;
    public int state;

    private void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
    }

    private void Start()
    {
        
    }
    
    public void ChangeState()
    {
        if(state == 0)
        {
            state = 1;

            image.sprite = onSprite;
        }
        else
        {
            state = 0;

            image.sprite = offSprite;
        }
    }
}
