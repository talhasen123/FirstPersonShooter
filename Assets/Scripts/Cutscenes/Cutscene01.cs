using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene01 : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject theCam1;
    public GameObject theCam2;
    public GameObject theUI;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(cutsceneBegin());
    }

    IEnumerator cutsceneBegin()
    {
        yield return new WaitForSeconds(4.5f);
        theCam2.SetActive(true);
        theCam1.SetActive(false);
        yield return new WaitForSeconds(4.5f);
        thePlayer.SetActive(true);
        theUI.SetActive(true);
        theCam2.SetActive(false);
    }
}
