using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpawn : MonoBehaviour
{
    public GameObject PowerPickUp, ShootSPickUp;

    public List<GameObject> pointsToSpawn;

    public int powerCounter, PowerCounter_trigger, ShootSCounter, ShootSCounterTrigger, score, kill_counter;

    void Start()
    {
        powerCounter = 0;
    }

    void Update()
    {
        if (powerCounter >= PowerCounter_trigger)
        {
            Instantiate(PowerPickUp, pointsToSpawn[ Random.Range(0,  pointsToSpawn.Count) ].transform.position, new Quaternion(0, 0, 0, 0), gameObject.transform);
            powerCounter = 0;
        }

        if(ShootSCounter >= ShootSCounterTrigger)
        {
            Instantiate(ShootSPickUp, pointsToSpawn[Random.Range(0, pointsToSpawn.Count)].transform.position, new Quaternion(0, 0, 0, 0), gameObject.transform);
            ShootSCounter = 0;
        }
    }
}
