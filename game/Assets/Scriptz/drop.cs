using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop : MonoBehaviour
{
    private Rigidbody2D RB;
    public float speed;
    Vector2 move_in;

    public UnityEngine.Animation animation_comp;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        move_in = new Vector2(0, 1);
        animation_comp = GetComponent<UnityEngine.Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        RB.velocity = move_in * speed * Time.deltaTime;

        if (transform.position.y <= -7)
        {
            Destroy(gameObject);
        }

        if(animation_comp.IsPlaying(animation_comp.name) == false)
        {
            animation_comp.Play();
        }
    }
}
