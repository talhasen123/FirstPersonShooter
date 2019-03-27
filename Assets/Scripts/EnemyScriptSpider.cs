using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptSpider : MonoBehaviour
{
    public int enemyHealth = 20;
    public GameObject theSpider;

    // Update is called once per frame
    void Update()
    {
        if ( enemyHealth <= 0)
        {
            GetComponent<SpiderFollow>().enabled = false;
            theSpider.GetComponent<Animation>().Play("die");
            StartCoroutine(endSpider());
            enemyHealth = 1;
        }
    }

    void DeductPoints(int damageAmount)
    {
        enemyHealth -= damageAmount;
    }

    IEnumerator endSpider()
    {
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
