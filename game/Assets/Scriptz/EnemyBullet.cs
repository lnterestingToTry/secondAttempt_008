using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int speed;
    public float speed_multiplier;

    public Vector2 move;

    Rigidbody2D rigidbody_;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody_ = transform.GetComponent<Rigidbody2D>();
        //move = new Vector2(Random.Range(-1, 1), 1);
        //speed = 50;
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody_.velocity = speed_multiplier * move * speed * Time.deltaTime;
        if (transform.position[1] < -6.4)
        {
            Destroy(gameObject);
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("3")) //player
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}
