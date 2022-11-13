using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionBounds : MonoBehaviour
{
    float life_time, left;
    void Start()
    {
        life_time = 13;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position[1] <= -7 || left > life_time)
        {
            Destroy(gameObject);
        }
        left += 0.1f * Time.timeScale;
    }
}
