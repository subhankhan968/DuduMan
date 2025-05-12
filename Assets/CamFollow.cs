using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject toFollow;
    [SerializeField]
    private GameObject boiBone;
    [SerializeField]
    private GameObject bikeBoiBone;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private PlayerManager pManager;

    public Camera cam;

    private Animator animator;

    int secs;

    void Awake()
    {
        //offset = this.transform.position;
        animator = this.gameObject.GetComponent<Animator>();
        cam = this.gameObject.GetComponent<Camera>();

        secs = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //this.gameObject.transform.position = toFollow.transform.position + offset;
        animator.SetFloat("direction", pManager.inputH.dir.x);

        if (!pManager.allowMovement)
        {
            if (pManager.collisionH.boi.activeSelf)
            {
                toFollow = boiBone;
            }
            else
            {
                toFollow = bikeBoiBone;
            }
        }
    }

    private void FixedUpdate()
    {
        //secs += 1;

        //if (gameManager.instance.pManager.allowMovement)
        //{
        //    if (gameManager.instance.pManager.collisionH.boi.activeSelf)
        //    {
        //        cam.transform.position = new Vector3(0, 0, -22);
        //    }
        //    else
        //    {
        //        cam.transform.position = new Vector3(0, 0, -30);
        //    }
        //}
        //else
        //{
        //    cam.transform.position = new Vector3(0, 0, -13);
        //}

        //if (secs >= 10)
        //{
            

        //    secs = 0;
        //}
    }
}
