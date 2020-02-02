using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] private AudioSource jumpAudio;
    public void PlaySound_Jump()
    {
        jumpAudio.Play();
    }
    [SerializeField] private AudioSource shootAudio;
    public void PlaySound_Shoot()
    {
        shootAudio.Play();
    }

    [SerializeField] private AudioSource hitAudio;
    public void PlaySound_Hit()
    {
        hitAudio.Play();
    }
    [SerializeField] private AudioSource deathAudio;
    public void PlaySound_Death()
    {
        deathAudio.Play();
    }

    [SerializeField] private AudioSource footStepAudio;
    [SerializeField] private AudioClip[] footStepClip;
    public void PlaySound_footStep(int num)
    {
        footStepAudio.clip = footStepClip[num];
        footStepAudio.Play();
    }

}
