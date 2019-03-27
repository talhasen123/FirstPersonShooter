using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunReload : MonoBehaviour
{
    public AudioSource reloadSound;
    public GameObject crossObject;
    public GameObject mechanicsObject;
    public GunFire gunComponent;
    public int clipAmount;
    public int reserveCount;
    public int reloadAvaible;

    void Start()
    {
        gunComponent = GetComponent<GunFire>();
    }

    // Update is called once per frame
    void Update()
    {
        clipAmount = GlobalAmmo.loadedAmmo;
        reserveCount = GlobalAmmo.currentAmmo;

        if ( reserveCount == 0)
        {
            reloadAvaible = 0;
        }
        else
        {
            reloadAvaible = 10 - clipAmount;
        }

        if (Input.GetButtonDown("Reload") && reloadAvaible >= 1)
        {
            if (reserveCount <= reloadAvaible)
            {
                GlobalAmmo.loadedAmmo += reserveCount;
                GlobalAmmo.currentAmmo -= reserveCount;
            }
            else
            {
                GlobalAmmo.loadedAmmo += reloadAvaible;
                GlobalAmmo.currentAmmo -= reloadAvaible;
            }
            actionReload();
            StartCoroutine(enableScripts());
            GunFire.aimSights = false;
        }
    }

    IEnumerator enableScripts()
    {
        yield return new WaitForSeconds(1.1f);
        gunComponent.enabled = true;
        crossObject.SetActive(true);
        mechanicsObject.SetActive(true);
    }

    void actionReload()
    {
        gunComponent.enabled = false;
        crossObject.SetActive(false);
        mechanicsObject.SetActive(false);
        reloadSound.Play();
        GetComponent<Animation>().Play("HandgunReload");
    }
}
