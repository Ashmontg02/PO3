using System;
using UnityEngine;

/// <summary>
///     1. 8-direcitonal movement
///     2. stop and face current direction when input is absent.
/// </summary>
public class MarioController : MonoBehaviour
{
    public AudioClip HHblip;
    public AudioClip Perform;
    public float velocity = 5.0f;
    public float turnSpeed = 10.0f;


    Vector2 input;
    float angle;

    Quaternion targetRotation;
    Transform cam;

    Animator anim;
    SongController songController;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        anim = GetComponent<Animator>();

        songController = GetComponent<SongController>();
    }

    
    void Update()
    {
        GetInput();
        GetPS4Input();
        if (Mathf.Abs(input.x) < 1 && Mathf.Abs(input.y) < 1) return;

        CalculateDirection();
        Rotate();
        Move();
    }

    void GetPS4Input()
    {
        //Square Button
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            Debug.Log("You pressed Square.");
        }

        //X Button
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            Debug.Log("You pressed X.");
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton2) && Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            Debug.Log("You're hitting both!");
            anim.SetTrigger("AttackCT");
            songController.storeNote("B");
            AudioSource.PlayClipAtPoint(HHblip, transform.position);
        }
        else
        {
            //Circle Button
            if (Input.GetKeyDown(KeyCode.JoystickButton2))
            {
                Debug.Log("You pressed Circle.");
                anim.SetTrigger("AttackCircle");
                songController.storeNote("C");
                AudioSource.PlayClipAtPoint(HHblip, transform.position);
            }

            //Triangle Button
            if (Input.GetKeyDown(KeyCode.JoystickButton3))
            {
                Debug.Log("You pressed Triangle.");
                anim.SetTrigger("AttackTriangle");
                songController.storeNote("T");
                AudioSource.PlayClipAtPoint(HHblip, transform.position);
            }
        }

        //R2 Button
        if (Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            Debug.Log("You pressed R2.");
            anim.SetTrigger("AttackR2");
            songController.playSong();
            AudioSource.PlayClipAtPoint(Perform, transform.position);
        }
    }

    /// <summary>
    /// Input based on horizontal (a,d,<,>) and vertical (w,s,^,v) keys.
    /// </summary>
    void GetInput()
    {
        input.x = Input.GetAxis("X-Axis");
        input.y = Input.GetAxis("Y-Axis");
        anim.SetFloat("BlendX", input.x);
        anim.SetFloat("BlendY", input.y);
    }

    /// <summary>
    /// Direction relative to the camera's rotation.
    /// </summary>
    void CalculateDirection()
    {
        angle = Mathf.Atan2(input.x, input.y);
        angle = Mathf.Rad2Deg * angle; // convert our Atan2 output (radians) to degrees.
        angle += cam.eulerAngles.y;
    }

    /// <summary>
    /// Rotate towards the calculated angle.
    /// </summary>
    void Rotate()
    {
        targetRotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }

    /// <summary>
    ///     The player moves along its forward axis.
    /// </summary>
    void Move()
    {
        transform.position += transform.forward * velocity * Time.deltaTime;
    }

}