using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelBlow : MonoBehaviour
{
    public int enemyHealth = 5;
    public GameObject theBarrel;
    public GameObject fakeBarrel;

    // Update is called once per frame
    void Update()
    {
        if ( enemyHealth <= 0)
        {
            theBarrel.SetActive(false);
            fakeBarrel.SetActive(true);
        }
    }

    void DeductPoints(int damageAmount)
    {
        enemyHealth -= damageAmount;
    }
}
