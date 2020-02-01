using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_BGM : MonoBehaviour
{
    
    [SerializeField] private float transitionTime =1.0f;
    [SerializeField] private float startVolume = 0.0f;
    [SerializeField] private float maxVolume = 1.0f;
    private AudioSource audioSource;
    void Start()
    {
       audioSource= this.gameObject.GetComponent<AudioSource>();
        audioSource.volume = 0;
        StartCoroutine(ChangeSoundVolume(startVolume,maxVolume));
    }

    IEnumerator ChangeSoundVolume(float startVolume,float maxVolume)
    {
        var time = startVolume * transitionTime ;
        while (transitionTime*maxVolume > time)
        {
            audioSource.volume = time / transitionTime;
            time += Time.deltaTime;
            yield return null;
        }
        audioSource.volume = maxVolume;
    }

    public void ChangeSound(float maxSound)
    {
        if (maxSound > 1.0f) maxSound = 1.0f;
        StartCoroutine(ChangeSoundVolume(maxVolume, maxSound));
        maxVolume = maxSound;
    }
}
