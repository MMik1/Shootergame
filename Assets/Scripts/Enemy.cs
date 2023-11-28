using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent badGuy;

    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;

    private float xPosistion;
    private float yPosistion;
    private float zPosistion;
    void Start()
    {
        newLocation();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void newLocation()
    {
        xPosistion = Random.Range(xMin, xMax);
        yPosistion = transform.position.y;
        zPosistion = Random.Range(zMin, zMax);
        badGuy.SetDestination(new Vector3(xPosistion, yPosistion, zPosistion));
    }
}