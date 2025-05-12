using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class milkMoneyGateInfo : MonoBehaviour
{
    public int value;
    public char operation;
    public bool buy; //true for milk gates. false for money gates

    public AudioClip milk;
    public AudioClip money;

    AudioSource audiosrc;

    private void Start()
    {
        audiosrc = this.gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (buy)
            {
                audiosrc.PlayOneShot(milk);
            }
            else
            {
                audiosrc.PlayOneShot(money);
            }
        }
    }
}
