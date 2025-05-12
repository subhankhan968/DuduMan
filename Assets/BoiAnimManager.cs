using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BoiAnimManager : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        this.transform.DOShakeScale(0.7f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
