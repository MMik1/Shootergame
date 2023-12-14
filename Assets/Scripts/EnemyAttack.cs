using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class EnemyAttack : MonoBehaviour
{
    public GameObject player;
    public float attackRange = 3f;

    private Enemy enemyScript;
    private bool foundPlayer;

    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.Find("Player");
        enemyScript = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= attackRange)
        {
            enemyScript.badGuy.SetDestination(player.transform.position);
            foundPlayer = true;
        }
        else if (foundPlayer)
        {
            enemyScript.newLocation();
            foundPlayer = false;
        }
    }
}
