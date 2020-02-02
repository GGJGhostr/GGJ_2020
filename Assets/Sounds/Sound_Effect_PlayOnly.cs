using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Effect_PlayOnly : MonoBehaviour
{
    [SerializeField] private int soundDataNumber  = 0; 
    
    public void SoundPlay()
    {
        var audio = Sound_Effect.Instance;
        audio.PlayEffectSound(soundDataNumber);
    }
}
