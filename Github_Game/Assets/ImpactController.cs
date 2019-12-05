using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactController : MonoBehaviour
{
    public AudioClip hitPomf;

    void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(hitPomf, other.transform.position);
        Debug.Log("Ouch");
    }
}
