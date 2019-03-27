using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public AudioSource ammoSound;
    void OnTriggerEnter( Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            ammoSound.Play();
            GlobalAmmo.currentAmmo += 10;
            this.gameObject.SetActive(false);
        }
    }
}
