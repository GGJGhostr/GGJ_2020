using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Effect : MonoBehaviour
{
    private static Sound_Effect instance = new Sound_Effect();
    public static Sound_Effect Instance => instance;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClipScriptable clips;

    public void ChangeVolume(float volumeSize)
    {
        audioSource.volume = volumeSize;
    }

        public void PlayEffectSound(int num)
    {
        audioSource.PlayOneShot(clips.audioClip[num]);
    }
}
