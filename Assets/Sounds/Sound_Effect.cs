using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class Sound_Effect : MonoBehaviour
{
    [SerializeField] [Range(0, 1)] private float volume = 1.0f;
    private AudioSource audioSource;
    [SerializeField] private AudioClipScriptable clips;
    private GamePad.PlayerIndex player_idx = GamePad.PlayerIndex.Any;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.volume = volume;
    }

    // Update is called once per frame
    void Update()
    {
        //debug
        GamepadState player_state = GamePad.GetState(player_idx);
        if (player_state.X)
        {
            PlayEffectSound(0);
        }
    }

    public void ChangeVolume(float volumeSize)
    {
        volume = volumeSize;
        audioSource.volume = volume;
    }

    public void PlayEffectSound(int num)
    {
        audioSource.PlayOneShot(clips.audioClip[num]);
    }
}
