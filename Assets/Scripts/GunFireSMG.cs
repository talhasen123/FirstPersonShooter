using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFireSMG : MonoBehaviour
{
    public AudioSource SMGSound;
    public GameObject muzzleFlash;
    public int ammoCount;
    public int firing;

    public GameObject upCurs, downCurs, leftCurs, rightCurs;

    // Update is called once per frame
    void Update()
    {
        ammoCount = GlobalAmmo.loadedAmmo;

        if ( Input.GetButton("Fire1"))
        {
            if ( ammoCount >= 1)
            {
                if ( firing == 0)
                {
                    StartCoroutine(SMGFire());
                }
            }
        }
    }

    IEnumerator SMGFire()
    {
        firing = 1;
        upCurs.GetComponent<Animator>().enabled = true;
        downCurs.GetComponent<Animator>().enabled = true;
        leftCurs.GetComponent<Animator>().enabled = true;
        rightCurs.GetComponent<Animator>().enabled = true;

        GlobalAmmo.loadedAmmo -= 1;
        SMGSound.Play();
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        muzzleFlash.SetActive(false);
        upCurs.GetComponent<Animator>().enabled = false;
        downCurs.GetComponent<Animator>().enabled = false;
        leftCurs.GetComponent<Animator>().enabled = false;
        rightCurs.GetComponent<Animator>().enabled = false;
        firing = 0;

    }

}
