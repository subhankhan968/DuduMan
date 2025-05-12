using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    internal InputHandler inputH;
    [SerializeField]
    internal MovementHandler movementH;
    [SerializeField]
    internal CollisionHandler collisionH;
    [SerializeField]
    internal PlayerSoundHandler soundH;

    [SerializeField]
    internal GameObject milkSplash;
    [SerializeField]
    internal GameObject moneySplash;

    internal bool isGrounded;

    internal Transform t;

    internal Rigidbody rb;

    [SerializeField]
    internal bool allowMovement;

    internal bool finished;
    internal bool failed;
    void Awake()
    {
        //gameManager.onGameStateChanged += GameManager_onGameStateChanged;

        allowMovement = true;
        finished = false;
        failed = false;

        t = this.gameObject.GetComponent<Transform>();
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    //internal void GameManager_onGameStateChanged(gameState state)
    //{
    //    if (state != gameState.gamePlay)
    //    {
    //        allowMovement = false;
    //    }
    //    else
    //    {
    //        allowMovement = true;
    //    }
    //    //throw new NotImplementedException();
    //}

    private void Start()
    {
        //allowMovement = true;
    }

    private void OnDestroy()
    {
        //gameManager.onGameStateChanged -= GameManager_onGameStateChanged;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
