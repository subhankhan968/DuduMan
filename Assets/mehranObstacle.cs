using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mehranObstacle : MonoBehaviour
{
    [SerializeField]
    bool startMove;
    [SerializeField]
    float speed;
    [SerializeField]
    Vector3 dir;

    //public AudioClip sound;
    //AudioSource audiosrc;
    private void Start()
    {
        //audiosrc = this.gameObject.GetComponent<AudioSource>();
        startMove = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            startMove = true;
    }

    private void FixedUpdate()
    {
        if (startMove)
        {
            this.transform.Translate(dir * speed);

            //if (!audiosrc.isPlaying)
            //{
            //    audiosrc.PlayOneShot(sound);
            //}
        }
    }
}
