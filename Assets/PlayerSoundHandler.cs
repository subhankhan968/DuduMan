using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundHandler : MonoBehaviour
{
    [SerializeField]
    internal PlayerManager pManager;

    [SerializeField]
    internal AudioClip footsteps;
    [SerializeField]
    internal AudioClip jump;
    [SerializeField]
    internal AudioClip lose;
    [SerializeField]
    internal AudioClip pickup;
    [SerializeField]
    internal AudioClip pickupEnd;

    [SerializeField]
    internal AudioSource audioSrc;
    [SerializeField]
    internal AudioSource SFXaudioSrc;

    private void Update()
    {
        if (pManager.collisionH.boi.activeSelf && pManager.allowMovement)
        {
            if (pManager.isGrounded)
            {
                audioSrc.clip = footsteps;
                audioSrc.loop = true;
                audioSrc.volume = 0.3f;
                if (!audioSrc.isPlaying)
                {
                    audioSrc.Play();
                }
            }
            else
            {
                audioSrc.clip = jump;
                audioSrc.loop = true;
                audioSrc.volume = 0.3f;
                if (!audioSrc.isPlaying)
                {
                    audioSrc.Play();
                }
            }
        }
        else
        {
            audioSrc.Stop();
        }
    }
}
