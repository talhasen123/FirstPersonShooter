using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup9mm : MonoBehaviour
{
    public GameObject textDisplay;
    public GameObject ammoDisplay;
    public GameObject fakeGun;
    public GameObject realGun;
    public AudioSource pickupAudio;
    public GameObject objectiveComplete;
    public float theDistance = PlayerCasting.distanceFromTarget;
    private bool completedObjective = false;
    public GameObject handgunUI;
    public GameObject smg;


    // Update is called once per frame
    void Update()
    {
        theDistance = PlayerCasting.distanceFromTarget;
        
    }

    void OnMouseOver()
    {
        if (theDistance <= 2)
        {
            textDisplay.GetComponent<Text>().text = "Take 9mm Pistol";
        }

        if (Input.GetButtonDown("Action"))
        {
            if (theDistance <= 2)
            {
                smg.SetActive(false);
                pickupAudio.Play();
                take9mm();
                objectiveComplete.SetActive(true);
                if ( !completedObjective)
                {
                    FinishLevel.completedObjectives++;
                    completedObjective = true;
                }
                handgunUI.SetActive(true);
                GunSwap.handgunPicked = true;
            }
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
