using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed;
    public int speed_multiplier;

    public GameObject particle;

    public Vector2 move;

    Rigidbody2D rigidbody_;

    public GameObject expl;

    public int damage;

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
        rigidbody_.velocity = move * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("0")) //enemy
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<Health>().hp -= damage;

            expl = Instantiate(expl, transform.position, new Quaternion(0, 0, 0, 0));
            Destroy(expl, 1f);
        }
        if (collision.gameObject.CompareTag("2")) //enemyBullet
        {
            //Destroy(collision.gameObject);
            //Destroy(gameObject);
            Destroy(gameObject);
            collision.gameObject.GetComponent<Health>().hp -= 1;

            expl = Instantiate(expl, transform.position, new Quaternion(0, 0, 0, 0));
            Destroy(expl, 1f);
        }
    }
}
