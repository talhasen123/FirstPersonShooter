using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int enemyHealth = 10;
    public GameObject theZombie;
    public GameObject zombieHead;

    // Update is called once per frame
    void Update()
    {
        if ( enemyHealth <= 0)
        {
            theZombie.GetComponent<Animation>().Play("Dying");
            StartCoroutine(endZombie());
        }
    }

    void DeductPoints(int damageAmount)
    {
        enemyHealth -= damageAmount;
    }

    IEnumerator endZombie()
    {
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        zombieHead.SetActive(false);
        GetComponent<ZombieFollow>().enabled = false;
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
