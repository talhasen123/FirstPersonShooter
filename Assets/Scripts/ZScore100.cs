using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZScore100 : MonoBehaviour
{
    public GameObject objectiveComplete;
    private bool completedObjective = false;

    void DeductPoints( int damageAmount)
    {
        GlobalScore.currentScore += 100;
        objectiveComplete.SetActive(true);
        if (!completedObjective)
        {
            FinishLevel.completedObjectives++;
            completedObjective = true;
        }
    }
}
