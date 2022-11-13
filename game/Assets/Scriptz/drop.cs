using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop : MonoBehaviour
{
    private Rigidbody2D RB;
    public float speed;
    Vector2 move_in;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        move_in = new Vector2(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        RB.velocity = move_in * speed * Time.deltaTime;

        if (transform.position.y <= -7)
        {
            Destroy(gameObject);
        }
    }
}
