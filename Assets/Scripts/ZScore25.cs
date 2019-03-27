using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZScore25 : MonoBehaviour
{
    public GameObject objectiveComplete;
    private bool completedObjective = false;

    void DeductPoints( int damageAmount)
    {
        GlobalScore.currentScore += 25;
        objectiveComplete.SetActive(true);
        if (!completedObjective)
        {
            FinishLevel.completedObjectives++;
            completedObjective = true;
        }
    }
}
