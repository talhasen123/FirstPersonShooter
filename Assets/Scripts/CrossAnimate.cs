using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossAnimate : MonoBehaviour
{
    public GameObject upCurs, downCurs, leftCurs, rightCurs;

    // Update is called once per frame
    void Update()
    {
        if ( GlobalAmmo.loadedAmmo >= 1 && Input.GetButtonDown("Fire1"))
        {
            upCurs.GetComponent<Animator>().enabled = true;
            downCurs.GetComponent<Animator>().enabled = true;
            leftCurs.GetComponent<Animator>().enabled = true;
            rightCurs.GetComponent<Animator>().enabled = true;
            StartCoroutine(waitingAnim());
        }
    }

    IEnumerator waitingAnim()
    {
        yield return new WaitForSeconds(0.1f);
        upCurs.GetComponent<Animator>().enabled = false;
        downCurs.GetComponent<Animator>().enabled = false;
        leftCurs.GetComponent<Animator>().enabled = false;
        rightCurs.GetComponent<Animator>().enabled = false;
    }
}
