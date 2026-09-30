using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour
{
    [SerializeField]
    private ButtonSlider bgmButton;
    [SerializeField]
    private ButtonSlider effectButton;
    private void Awake()
    {
        bgmButton.state = (int)SoundManager.Instance.BGMPlayer.GetComponent<AudioSource>().volume;
       effectButton.state = (int)SoundManager.Instance.EffectPlayer.GetComponent<AudioSource>().volume;

        bgmButton.GetComponent<Button>().onClick.AddListener(SoundManager.Instance.ToggldBGMSound1);
        effectButton.GetComponent<Button>().onClick.AddListener(SoundManager.Instance.ToggldEffectSound1);

    }

}
