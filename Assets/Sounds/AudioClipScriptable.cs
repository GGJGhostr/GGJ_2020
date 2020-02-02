using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UI/AudioClip", fileName = "AudioClip")]

public class AudioClipScriptable : ScriptableObject
{
    [SerializeField] private AudioClip[] _audioClip = null;

    public AudioClip[] audioClip => _audioClip;
}
