using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMovement : MonoBehaviour
{
    Transform t;
    //Rigidbody rb;
    Vector3 dir;
    public Joystick joystick;
    [SerializeField]
    private float speed;

    Animator _animator;
    private void Start()
    {
        dir = Vector3.forward;
        t = this.gameObject.GetComponent<Transform>();
        _animator = this.transform.GetChild(0).GetComponent<Animator>();
        //rb = this.gameObject.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    TurnCar();
        //}
    }
    void FixedUpdate()
    {
        //rb.AddForce(0, 0, speed, ForceMode.Force);
        Vector2 dir2D = joystick.Direction.normalized;
        dir = new Vector3(dir2D.x, 0, dir2D.y);
        t.Translate(dir * speed, Space.Self);
        Debug.Log(dir);
    }

    void TurnCar()
    {
        _animator.Play("carTurnRight");
        transform.Rotate(0, 90, 0);
        //transform.GetChild(0).Rotate(0, -90, 0);
    }
}
