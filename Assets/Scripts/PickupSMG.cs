using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupSMG : MonoBehaviour
{
    public GameObject textDisplay;
    public GameObject ammoDisplay;
    public GameObject fakeGun;
    public GameObject realGun;
    public AudioSource pickupAudio;
    public GameObject objectiveComplete;
    public GameObject mechanics;
    public float theDistance = PlayerCasting.distanceFromTarget;
    public GameObject MP5KUI;
    public GameObject handgun;


    // Update is called once per frame
    void Update()
    {
        theDistance = PlayerCasting.distanceFromTarget;
        
    }

    void OnMouseOver()
    {
        if (theDistance <= 2)
        {
            textDisplay.GetComponent<Text>().text = "Pick Up SMG";
        }

        if (Input.GetButtonDown("Action"))
        {
            if (theDistance <= 2)
            {
                handgun.SetActive(false);
                pickupAudio.Play();
                take9mm();
                mechanics.SetActive(true);
                objectiveComplete.SetActive(true);
            }
            MP5KUI.SetActive(true);
            GunSwap.smgPicked = true;
        }
    }

    void OnMouseExit()
    {
        textDisplay.GetComponent<Text>().text = "";
    }

    void take9mm()
    {
        transform.position = new Vector3(0, -10000, 0);
        fakeGun.SetActive(false);
        realGun.SetActive(true);
        ammoDisplay.SetActive(true);
    }
}
