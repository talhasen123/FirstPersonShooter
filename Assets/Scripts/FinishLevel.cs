using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public static int completedObjectives = 0;
    public GameObject normalObjectives;
    public GameObject finalObjective;
    public GameObject textDisplay;
    public GameObject objectiveComplete;
    public float theDistance;


    // Update is called once per frame
    void Update()
    {
        theDistance = PlayerCasting.distanceFromTarget;

        if ( completedObjectives == 3)
        {
            normalObjectives.SetActive(false);
            finalObjective.SetActive(true);
        }
    }

    void OnMouseOver()
    {
        if ( completedObjectives == 3)
        {
            if (theDistance <= 3)
            {
                textDisplay.GetComponent<Text>().text = "Open The Door";
                textDisplay.SetActive(true);
                if (Input.GetButtonDown("Action"))
                {
                    if (theDistance <= 3)
                    {
                        GetComponent<BoxCollider>().enabled = false;
                        textDisplay.GetComponent<Text>().text = "";
                        textDisplay.SetActive(false);
                        objectiveComplete.SetActive(true);
                        SceneManager.LoadScene(6);
                    }
                }
            }    
        }
    }

    void OnMouseExit()
    {
        textDisplay.GetComponent<Text>().text = "";
    }
}
