using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    public GameObject flash;
    public GameObject upCurs;
    public GameObject downCurs;
    public GameObject leftCurs;
    public GameObject rightCurs;
    public static bool aimSights;

    // Update is called once per frame
    void Update()
    {
        if ( GlobalAmmo.loadedAmmo >= 1 && Input.GetButtonDown("Fire1") )
        {
            AudioSource gunSound = GetComponent<AudioSource>();
            gunSound.Play();
            flash.SetActive(true);
            StartCoroutine(muzzleOff());
            GetComponent<Animation>().Play("GunShot");
            GlobalAmmo.loadedAmmo -= 1;
        }

        if ( aimSights)
        {
            upCurs.SetActive(false);
            downCurs.SetActive(false);
            leftCurs.SetActive(false);
            rightCurs.SetActive(false);
        }
        else
        {
            upCurs.SetActive(true);
            downCurs.SetActive(true);
            leftCurs.SetActive(true);
            rightCurs.SetActive(true);
        }

        if ( Input.GetButtonDown("Fire2") && !aimSights)
        {
            GetComponent<Animation>().Play("AimSights");
            aimSights = !aimSights;          
        }
        else if (Input.GetButtonDown("Fire2") && aimSights)
        {
            GetComponent<Animation>().Play("NotAimSights");
            aimSights = !aimSights;
        }
    }

    IEnumerator muzzleOff()
    {
        yield return new WaitForSeconds(0.1f);
        flash.SetActive(false);
    }
}
