using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelBang : MonoBehaviour
{
    public AudioSource bangSound;

    void OnCollisionEnter( Collision collision)
    {
        if ( collision.relativeVelocity.magnitude > 1)
        {
            bangSound.Play();
        }
    }
}
