using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunDamage : MonoBehaviour
{
    public int damageAmount;
    public float targetDistance;
    public float allowedRange = 15f;

    public RaycastHit hit;
    public GameObject bullet;
    public GameObject blood;
    public GameObject bloodGreen;

    void Start()
    {
        damageAmount = 5;
    }

    void Update()
    {
        if ( GlobalAmmo.loadedAmmo >= 1 && Input.GetButtonDown("Fire1"))
        {
            RaycastHit shot;
            if ( Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
            {
                targetDistance = shot.distance;
                if ( targetDistance < allowedRange)
                {
                    if ( Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
                    {
                        if (hit.collider.tag == "ZombieHead")
                        {
                            damageAmount = 10;
                            Instantiate(blood, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                        }
                        else if ( hit.transform.tag == "Zombie")
                        {
                            Instantiate(blood, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                        }
                        else if (hit.transform.tag == "Spider")
                        {
                            Instantiate(bloodGreen, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                        }
                        else
                        {
                            Instantiate(bullet, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                        }
                    }
                    shot.transform.SendMessage("DeductPoints", damageAmount, SendMessageOptions.DontRequireReceiver);
                    damageAmount = 5;
                }
            }
        }
    }
}
