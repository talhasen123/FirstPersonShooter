using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject theEnemy;
    public float enemySpeed;
    public bool enemyTrigger;

    // Update is called once per frame
    void Update()
    {
        if (enemyTrigger)
        {
            enemySpeed = 0.02f;
            transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, enemySpeed);
        }
    }
}
