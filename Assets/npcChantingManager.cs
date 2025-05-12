using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcChantingManager : MonoBehaviour
{
    [SerializeField]
    AudioClip chantDefault;
    [SerializeField]
    AudioClip[] chants;

    public bool normal;

    AudioSource audiosrc;

    private void Awake()
    {
        audiosrc = this.gameObject.GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (normal)
        {
            audiosrc.pitch = 1.1f;
            audiosrc.clip = chantDefault;
            audiosrc.volume = 0.6f;
            audiosrc.Play();
        }
        else
        {
            audiosrc.pitch = Random.Range(0.9f, 1.1f);
            int soundID = Random.Range(0, chants.Length);
            audiosrc.clip = chants[soundID];
            audiosrc.loop = false;
            audiosrc.volume = 1f;
            if (soundID == 3)
            {
                audiosrc.volume = 0.9f;
            }
        }
    }

    private void Update()
    {
        if (!normal)
        {
            if (!audiosrc.isPlaying)
            {
                audiosrc.PlayDelayed(Random.Range(0, 0.2f));
            }
        }
    }

    IEnumerator delayPlay(float sec)
    {
        yield return new WaitForSeconds(sec);
        audiosrc.Play();
    }
}
