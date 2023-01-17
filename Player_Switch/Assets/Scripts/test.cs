using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public VariableJoystick joystick;
    private void Update()
    {
        var dir = joystick.Direction;
        var movement = new Vector3(dir.x, 0, dir.y);
        transform.position += movement;
    }
}
