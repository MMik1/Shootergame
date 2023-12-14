using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    // Start is called before the first frame update
    public NavMeshAgent badGuy;

    public float squareOfMovement = 20f;
    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;


    private float xPosition;
    private float yPosition;
    private float zPosition;

    public float closeEnough = 3f;
    void Start()
    {

        xMin = zMin = -squareOfMovement;
        xMax = zMax = squareOfMovement;
        newLocation();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, new Vector3(xPosition, yPosition, zPosition)) <= closeEnough)
        {
            newLocation();
        }
    }

    public void newLocation()
    {
        xPosition = Random.Range(xMin, xMax);
        yPosition = transform.position.y;
        zPosition = Random.Range(zMin, zMax);
        badGuy.SetDestination(new Vector3(xPosition, yPosition, zPosition));
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Boom");
            PlayerMovement playerMovement = collision.collider.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.Die();
            }
        }
    }
}