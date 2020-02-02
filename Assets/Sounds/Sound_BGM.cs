using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_BGM : MonoBehaviour
{
    
    [SerializeField] private float delayTime = 1.0f;
    [SerializeField] private float startVolume = 0.0f;
    [SerializeField] [Range(0,1)]private float endVolume = 1.0f;
    private AudioSource audioSource;
    void Start()
    {
       audioSource= this.gameObject.GetComponent<AudioSource>();
        audioSource.volume = 0;
        StartCoroutine(ChangeSoundVolume(startVolume,endVolume, delayTime));
    }

    IEnumerator ChangeSoundVolume(float startVolume,float endVolume,float delayTime)
    {
        var time = delayTime*audioSource.volume;
        while (delayTime > time)
        {
            audioSource.volume = Mathf.Lerp(startVolume, endVolume, time/delayTime);
            time += Time.deltaTime;
            yield return null;
        }
        audioSource.volume = endVolume;
    }

    public void ChangeSound(float maxSound)
    {
        if (maxSound > 1.0f) maxSound = 1.0f;
        StartCoroutine(ChangeSoundVolume(audioSource.volume, maxSound,delayTime));
    }
}
