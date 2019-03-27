using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreekyDoorOpen : MonoBehaviour
{
    public float theDistance;
    public GameObject actionDisplay;
    public GameObject theDoor;
    public AudioSource creekSound;

    // Update is called once per frame
    void Update()
    {
        theDistance = PlayerCasting.distanceFromTarget;
    }

    void OnMouseOver()
    {
        if ( theDistance <= 3)
        {
            actionDisplay.GetComponent<Text>().text = "Open The Door";
            actionDisplay.SetActive(true);
            if ( Input.GetButtonDown("Action"))
            {
                GetComponent<BoxCollider>().enabled = false;
                actionDisplay.GetComponent<Text>().text = "";
                actionDisplay.SetActive(false);
                theDoor.GetComponent<Animation>().Play("OpenDoorAbandonedAnim");
                creekSound.Play();
            }
        }
    }

    void OnMouseExit()
    {
        actionDisplay.GetComponent<Text>().text = "";
        actionDisplay.SetActive(false);
    }
}
