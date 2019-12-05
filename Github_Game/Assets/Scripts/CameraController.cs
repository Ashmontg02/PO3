using System.Collections;
using UnityEngine;

/// <summary>
///     1. Follow on X/Z plane.
///     2. Smooth rotations around the player in 45 degree increments.
/// </summary>
public class CameraController : MonoBehaviour
{

    public Transform target;
    public Vector3 offsetPos;
    public float moveSpeed = 5.0f;
    public float turnSpeed = 10.0f;
    public float smoothSpeed = 0.5f;

    Quaternion targetRotation;
    Vector3 targetPos;
    bool smoothRotating = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveWithTarget();
        LookAtTarget();

        if (Input.GetKeyDown(KeyCode.G) && !smoothRotating)
        {
            StartCoroutine("RotateAroundTarget", 45);
        }

        if (Input.GetKeyDown(KeyCode.H) && !smoothRotating)
        {
            StartCoroutine("RotateAroundTarget", -45);
        }
    }

    /// <summary>
    ///     Moves the camera to the player position and current offset defined above.
    /// </summary>
    void MoveWithTarget()
    {
        targetPos = target.position + offsetPos;
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }

    /// <summary>
    ///     Uses the "look vector" (defined as target position - current position) to point the camera at the player
    /// </summary>
    void LookAtTarget()
    {
        targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }

    /// <summary>
    ///     Should only ever have one of these going at a time.
    /// </summary>
    IEnumerator RotateAroundTarget(float angle)
    {
        var vel = Vector3.zero;
        var targetOffsetPos = Quaternion.Euler(0, angle, 0) * offsetPos;
        var dist = Vector3.Distance(offsetPos, targetOffsetPos);
        smoothRotating = true;
        
        while (dist > 0.02f) // magic number
        {
            offsetPos = Vector3.SmoothDamp(offsetPos, targetOffsetPos, ref vel, smoothSpeed);
            dist = Vector3.Distance(offsetPos, targetOffsetPos);
            yield return null;
        }

        smoothRotating = false;
        offsetPos = targetOffsetPos;
    }

}
