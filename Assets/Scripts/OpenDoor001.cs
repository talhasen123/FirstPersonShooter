using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor001 : MonoBehaviour
{
    public GameObject textDisplay;
    public GameObject theDoor;
    public GameObject objectiveComplete;
    public float theDistance = PlayerCasting.distanceFromTarget;
    private bool completedObjective = false;

    void Update()
    {
        theDistance = PlayerCasting.distanceFromTarget;
        
    }

    void OnMouseOver()
    {
        if ( theDistance <= 2)
        {
            textDisplay.GetComponent<Text>().text = "Open The Door";
        }

        if (Input.GetButtonDown("Action"))
        {
            if (theDistance <= 2)
            {
                StartCoroutine(openTheDoor());
                objectiveComplete.SetActive(true);
                if (!completedObjective)
                {
                    FinishLevel.completedObjectives++;
                    completedObjective = true;
                }
            }
        }
    }

    void OnMouseExit()
    {
        textDisplay.GetComponent<Text>().text = "";
    }
    
    IEnumerator openTheDoor()
    {
        theDoor.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(1);
        theDoor.GetComponent<Animator>().enabled = false;
        yield return new WaitForSeconds(3);
        theDoor.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(1);
        theDoor.GetComponent<Animator>().enabled = false;
    }
}
