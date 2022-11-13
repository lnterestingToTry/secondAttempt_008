using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rigidbody_;
    Vector2 move_in;
    public float speed;
    public float speed_mult;

    void Start()
    {
        speed_mult = 1;
        rigidbody_ = transform.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
            if (transform.position[0] > mouse_position[0])
            {
                //move_in += new Vector2(-1, 0f);
                if (transform.position[0] - speed < mouse_position[0])
                {
                    move_in += new Vector2(mouse_position[0] - transform.position[0], 0f); 
                }
                else
                {
                    move_in -= new Vector2(1, 0f);
                }
            }
            else if (transform.position[0] < mouse_position[0])
            {
                //move_in += new Vector2(1, 0f);
                if (transform.position[0] + speed > mouse_position[0])
                {
                    move_in += new Vector2(mouse_position[0] - transform.position[0], 0f);
                }
                else
                {
                    move_in += new Vector2(1, 0f);
                }
            }

            if (transform.position[1] > mouse_position[1])
            {
                //move_in += new Vector2(0f, -1);
                if (transform.position[1] - speed < mouse_position[1])
                {
                    move_in += new Vector2(0f, mouse_position[1] - transform.position[1]);
                }
                else
                {
                    move_in -= new Vector2(0f, 1);
                }
            }
            else if (transform.position[1] < mouse_position[1])
            {
                //move_in += new Vector2(0f, 1);
                if (transform.position[1] + speed > mouse_position[1])
                {
                    move_in += new Vector2(0f, mouse_position[1] - transform.position[1]);
                }
                else
                {
                    move_in += new Vector2(0f, 1);
                }
            }
        }

        rigidbody_.velocity = speed_mult * move_in * speed * Time.deltaTime;
        move_in = new Vector2(0f, 0f);
    }
}
