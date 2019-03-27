using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwap : MonoBehaviour
{
    public GameObject handgunUI;
    public GameObject MP5KUI;
    public GameObject handgun;
    public GameObject MP5K;
    public GunFire handgunMechanics;
    public GunFireSMG smgMechanics;
    public static bool handgunPicked = false;
    public static bool smgPicked = false;

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Alpha1) && handgunPicked && !handgun.activeSelf)
        {
            StartCoroutine(equipM9());
        }
        else if ( Input.GetKeyDown(KeyCode.Alpha2) && smgPicked && !MP5K.activeSelf)
        {
            StartCoroutine(equipMP5K());
        }
    }

    IEnumerator equipM9()
    {
        handgunMechanics.enabled = false;
        smgMechanics.enabled = false;
        handgunUI.GetComponent<Animation>().Play("9mmUIFazeIn");
        MP5KUI.GetComponent<Animation>().Play("MP5KUIFazeOut");
        MP5K.GetComponent<Animation>().Play("MP5KUnequip");
        yield return new WaitForSeconds(1);
        MP5K.SetActive(false);
        handgun.SetActive(true);
        handgun.GetComponent<Animation>().Play("M9Equip");
        yield return new WaitForSeconds(1);
        handgunMechanics.enabled = true;
        smgMechanics.enabled = true;
    }

    IEnumerator equipMP5K()
    {
        handgunMechanics.enabled = false;
        smgMechanics.enabled = false;
        handgunUI.GetComponent<Animation>().Play("9mmUIFazeOut");
        MP5KUI.GetComponent<Animation>().Play("MP5KUIFazeIn");
        handgun.GetComponent<Animation>().Play("M9Unequip");
        yield return new WaitForSeconds(1);
        handgun.SetActive(false);
        MP5K.SetActive(true);
        MP5K.GetComponent<Animation>().Play("MP5KEquip");
        yield return new WaitForSeconds(1);
        handgunMechanics.enabled = true;
        smgMechanics.enabled = true;
    }
}
