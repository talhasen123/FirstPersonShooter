using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalAmmo : MonoBehaviour
{
    public static int currentAmmo;
    public static int loadedAmmo;
    public int internalAmmo;
    public int internalLoaded;
    public GameObject ammoDisplay;
    public GameObject loadedDisplay;

    // Update is called once per frame
    void Update()
    {
        internalAmmo = currentAmmo;
        internalLoaded = loadedAmmo;
        ammoDisplay.GetComponent<Text>().text = "" + internalAmmo;
        loadedDisplay.GetComponent<Text>().text = "" + internalLoaded;
    }
}
