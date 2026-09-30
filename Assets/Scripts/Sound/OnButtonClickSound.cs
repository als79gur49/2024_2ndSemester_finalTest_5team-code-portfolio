using UnityEngine;

public class OnButtonClickSound : MonoBehaviour
{
    //Button 컴포넌트의 On Click() 이벤트에 직접 붙히기.
    public void BasicSound()
    {
        if(SoundManager.Instance.PlayEffectAudio("Click"))
        {
            //추가 내용
        }
        else
        {
            Debug.Log("Click에 해당하는 소리를 찾을 수 없음");
        }
    }

    public void BattleStartSound()
    {
        if(SoundManager.Instance.PlayEffectAudio("BattleStart"))
        {
            //
        }
        else
        {
            Debug.Log("BattleStart에 해당하는 소리를 찾을 수 없음");
        }
    }

    public void PlayerUnitSpawnSound()
    {
        if (SoundManager.Instance.PlayEffectAudio("PlayerUnitSpawn"))
        {
            //
        }
        else
        {
            Debug.Log("PlayerUnitSpawn에 해당하는 소리를 찾을 수 없음");
        }
    }
}
