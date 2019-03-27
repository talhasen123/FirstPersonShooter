using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickupSMG : MonoBehaviour
{
    public AudioSource ammoSound;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            ammoSound.Play();
            if (GlobalAmmo.loadedAmmo == 0)
            {
                GlobalAmmo.loadedAmmo += 30;
            }
            else
            {
                GlobalAmmo.currentAmmo += 30;
            }
            this.gameObject.SetActive(false);
        }
    }
}
