using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //PS4 Controller Inputs

        //Square Button
        if(Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            Debug.Log("You pressed Square.");
        }

        //X Button
        if(Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            Debug.Log("You pressed X.");
        }

        //Circle Button
        if(Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            Debug.Log("You pressed Circle.");
        }

        //Triangle Button
        if(Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            Debug.Log("You pressed Triangle.");
        }

        //R2 Button
        if(Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            Debug.Log("You pressed R2.");
        }

        //Left Stick X
        if(Input.GetAxis("X-Axis") != 0)
        {
            Debug.Log("You're moving the left joystick along the X-Axis.");
        }

        //Left Stick Y
        if(Input.GetAxis("Y-Axis") != 0)
        {
            Debug.Log("You're moving the left joystick along the Y-Axis.");
        }

        ////Right Stick X
        //if(Input.GetAxis("3rd-Axis") != 0)
        //{
        //    Debug.Log("You're moving the right joystick along the X-Axis.");
        //}

        ////Right Stick Y
        //if(Input.GetAxis("4th-Axis") != 0)
        //{
        //    Debug.Log("You're moving the right joystick along the Y-Axis.");
        //}
    }
}
