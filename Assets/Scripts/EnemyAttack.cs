using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAttack : MonoBehaviour
{ 
    public Transform player;
    public float attackRange = 3f;

    private Enemy enemyScript;

    public Material defaultMaterial;
    public Material allerMaterial;
    public Renderer ren;
    // Start is called before the first frame update
    void Start()
    {
        enemyScript = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            ren.sharedMaterial = allerMaterial;
            enemyScript.badGuy.SetDestination(player.position);
        }
        else
        {
            ren.sharedMaterial = defaultMaterial;
            enemyScript.newLocation();
        }
    }
}