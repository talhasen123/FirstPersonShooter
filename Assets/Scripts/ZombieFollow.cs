using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFollow : MonoBehaviour
{
    public GameObject thePlayer;
    public float targetDistance;
    public float allowedRange = 10;
    public GameObject theEnemy;
    public float enemySpeed;
    public bool attackTrigger;
    public RaycastHit shot;

    public bool isAttacking;
    public GameObject hurtScreen;
    public AudioSource hurt1, hurt2, hurt3;
    public int painSound;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(thePlayer.transform);
        if ( Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
        {
            targetDistance = shot.distance;
            if (targetDistance < allowedRange)
            {
                enemySpeed = 0.02f;
                if (!attackTrigger)
                {
                    theEnemy.GetComponent<Animation>().Play("Walking");
                    transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, Time.deltaTime);
                }
            }
            else
            {
                enemySpeed = 0;
                theEnemy.GetComponent<Animation>().Play("Idle");
            }
        }

        if ( attackTrigger)
        {
            if ( !isAttacking)
            {
                StartCoroutine(enemyDamage());
            }
            enemySpeed = 0;
            theEnemy.GetComponent<Animation>().Play("Attacking");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyAttackTrigger")
        {
            attackTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "EnemyAttackTrigger")
        {
            attackTrigger = false;
        }
    }

    IEnumerator enemyDamage()
    {
        isAttacking = true;
        painSound = Random.Range(1, 4);
        yield return new WaitForSeconds(0.9f);
        hurtScreen.SetActive(true);
        GlobalHealth.playerHealth -= 2;
        if ( painSound == 1)
        {
            hurt1.Play();
        }
        else if ( painSound == 2)
        {
            hurt2.Play();
        }
        else
        {
            hurt3.Play();
        }
        yield return new WaitForSeconds(0.05f);
        hurtScreen.SetActive(false);
        yield return new WaitForSeconds(1);
        isAttacking = false;
    }
}
