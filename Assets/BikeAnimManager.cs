using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BikeAnimManager : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    PlayerManager pManager;
    [SerializeField]
    private float maxTilt;

    [SerializeField]
    GameObject appearGfx;

    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        if (this.transform.name == "Boi")
        {
            maxTilt = 0.69f;
        }
        else
        {
            maxTilt = 1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("speed", pManager.rb.velocity.magnitude);
        if (pManager.inputH.dir.x > maxTilt && pManager.inputH.dir.x > 0)
        {
            animator.SetFloat("direction", maxTilt);
        }
        else
        {
            animator.SetFloat("direction", pManager.inputH.dir.x);
        }
        animator.SetBool("isGrounded", pManager.isGrounded);
        animator.SetBool("finished", pManager.finished);
    }

    private void OnEnable()
    {
        this.transform.DOShakeScale(0.7f);
        Instantiate(appearGfx, this.gameObject.transform.parent);
    }
}
