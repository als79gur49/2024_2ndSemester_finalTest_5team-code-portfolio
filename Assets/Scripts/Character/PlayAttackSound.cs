
using UnityEngine;

public class PlayAttackSound : MonoBehaviour
{
    public void MeleeAttackSound()
    {
        SoundManager.Instance.PlayEffectAudio("MeleeAttack");
    }

    public void RangeAttackSound()
    {
        SoundManager.Instance.PlayEffectAudio("RangeAttack");
    }
}
