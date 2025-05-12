using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovementHandler : MonoBehaviour
{
    [SerializeField]
    internal PlayerManager pManager;
    [SerializeField]
    internal Transform[] target;
    [SerializeField]
    internal float turnSpeed;
    [SerializeField]
    internal Rigidbody rb;
    [SerializeField]
    internal float maxWidth;
    [SerializeField]
    internal float maxRunSpeed;
    [SerializeField]
    internal float maxBikeSpeed;
    private int current;
    internal float moveSpeed;

    Transform t;
    Vector3 dir;
    //[SerializeField]
    //float damping;
    void Start()
    {
        t = pManager.t;
        rb = pManager.rb;
        dir = pManager.inputH.dir;
        moveSpeed = 20;
    }

    // Update is called once per frame
    void Update()
    {
        dir = pManager.inputH.dir;
        Vector3 targetPos = dir + t.position;

        //if(t.position != target[current].position)
        //{
        //    Vector3 pos = Vector3.MoveTowards(t.position, target[current].position, moveSpeed * Time.deltaTime);

        //}

        float maxSpeed = 0;
        if (pManager.allowMovement)
        {
            if (pManager.collisionH.boi.activeSelf)
            {
                maxSpeed = maxRunSpeed;
            }
            else if (pManager.collisionH.bike.activeSelf)
            {
                maxSpeed = maxBikeSpeed;
            }
        }
        else
        {
            maxSpeed = 0;
        }
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(Vector3.forward * moveSpeed * Time.deltaTime, ForceMode.VelocityChange);
            //rb.MovePosition(transform.position + Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else if (rb.velocity.magnitude > maxSpeed + 5)
        {
            rb.AddForce(Vector3.forward * (-moveSpeed) * Time.deltaTime, ForceMode.VelocityChange);
        }

        if (pManager.allowMovement)
        {
            if ((dir.x > 0 && t.position.x < maxWidth) || (dir.x < 0 && t.position.x > -maxWidth))
            {
                //t.Translate(dir * turnSpeed * Time.deltaTime, Space.World);
                rb.MovePosition(transform.position + dir * turnSpeed * Time.deltaTime);
            }
        }

        //position correction
        //if (t.position.x < -maxWidth)
        //{
        //    t.Translate(Vector3.right * turnSpeed * Time.deltaTime, Space.World);
        //}
        //else if (t.position.x > maxWidth)
        //{
        //    t.Translate(Vector3.right * -turnSpeed * Time.deltaTime, Space.World);
        //}


        //t.GetChild(0).transform.Translate(dir * turnSpeed * Time.deltaTime, Space.World);
        //rb.AddForce(dir * turnSpeed * Time.deltaTime, ForceMode.VelocityChange);










        //t.LookAt(targetPos);

        /*var rotation = Quaternion.LookRotation(dir);
        t.rotation = Quaternion.Slerp(t.rotation, rotation, Time.deltaTime * damping);*/

        //float step = rotateSpeed * Time.deltaTime;

        //Vector3 newDir = Vector3.RotateTowards(t.forward, dir, step, 0.0F);
        //Debug.DrawRay(transform.position, dir, Color.red);

        //t.rotation = Quaternion.LookRotation(dir);
    }

    private void FixedUpdate()
    {
        driftCorrection();
    }

    void driftCorrection()
    {
        if(dir.magnitude<0.1 && pManager.allowMovement)
        {
            pManager.rb.constraints = RigidbodyConstraints.FreezePositionX;
            pManager.rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        else
        {
            pManager.rb.constraints = RigidbodyConstraints.None;
            pManager.rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }
}
