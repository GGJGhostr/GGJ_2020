using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{

    public AudioSource sfx_shoot = null;
    public AudioSource sfx_footstep = null;
    public AudioSource sfx_jump = null;

    private void Awake()
    {
    }

    

    public void playShoot()
    {
        sfx_shoot.Play();
    }
}
