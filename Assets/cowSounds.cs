using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cowSounds : MonoBehaviour
{
    [SerializeField]
    AudioClip[] Sounds;
    AudioSource audiosrc;

    private void Start()
    {
        audiosrc = this.gameObject.GetComponent<AudioSource>();

        audiosrc.clip = Sounds[Random.Range(0, Sounds.Length)];
        audiosrc.loop = false;
    }

    private void Update()
    {
        if (!audiosrc.isPlaying)
        {
            audiosrc.PlayDelayed(Random.Range(0, 0.2f));
        }
    }
}
