using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMGDamage : MonoBehaviour
{
    public int damageAmount = 5;
    public float targetDistance;
    public float allowedRange = 15f;

    void Update()
    {
        if ( GlobalAmmo.loadedAmmo >= 1 && Input.GetButton("Fire1"))
        {
            RaycastHit shot;
            if ( Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
            {
                targetDistance = shot.distance;
                if ( targetDistance < allowedRange)
                {
                    shot.transform.SendMessage("DeductPoints", damageAmount, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}
