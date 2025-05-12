using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField]
    internal PlayerManager pManager;
    [SerializeField]
    internal Joystick joystick;

    internal Vector3 dir;
    void Start()
    {
        dir = Vector3.forward;
    }

    void Update()
    {
        Vector2 dir2D = joystick.Direction;
        dir = new Vector3(dir2D.x, 0, dir2D.y);
    }
}
