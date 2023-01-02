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
            GameObject g = Instantiate(PowerPickUp, pointsToSpawn[ Random.Range(0,  pointsToSpawn.Count) ].transform.position, new Quaternion(0, 0, 0, 0), gameObject.transform);
            g.transform.position = new Vector3(g.transform.position.x, g.transform.position.y, -2);
            powerCounter = 0;
        }

        if(ShootSCounter >= ShootSCounterTrigger)
        {
            GameObject g = Instantiate(ShootSPickUp, pointsToSpawn[Random.Range(0, pointsToSpawn.Count)].transform.position, new Quaternion(0, 0, 0, 0), gameObject.transform);
            g.transform.position = new Vector3(g.transform.position.x, g.transform.position.y, -2);
            ShootSCounter = 0;
        }
    }
}
