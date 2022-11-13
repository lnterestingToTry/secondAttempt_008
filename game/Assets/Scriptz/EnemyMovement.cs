using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Vector2 move;
    Rigidbody2D rigidbody_;
    public float speed;

    void Start()
    {
        //Random.InitState(Time_seed());
        rigidbody_ = transform.GetComponent<Rigidbody2D>();
        //move = new Vector2(Random.Range(-10, 10), -20);
        //move[1] = -50;
    }

    void Update()
    {
        rigidbody_.velocity = speed * move * Time.deltaTime;
    }

    public static int Time_seed()
    {
        return System.DateTime.UtcNow.GetHashCode();
    }
}
