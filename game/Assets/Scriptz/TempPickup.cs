using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPickup : MonoBehaviour
{
    private SpriteRenderer SR;
    public List<Sprite> anim_list;

    private float last_update;
    public float delay_per_frame;
    private int frame;

    public float delay_before_delate;

    public bool need_to_destroy;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        //delay_per_frame = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (frame < anim_list.Count)
        {
            if (Time.time - last_update > delay_per_frame)
            {
                last_update = Time.time;

                SR.sprite = anim_list[frame];
                frame += 1;

            }
        }
        else if (need_to_destroy == true)
        {
            Destroy(gameObject, delay_before_delate);
        }
        else
        {
            frame = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("3")) //player
        {
            Triggered(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void Triggered(GameObject player)
    {
        TempController scr = player.GetComponent<TempController>();

        int random = Random.Range(0, 4);
        Debug.Log(random);
        scr.tempNow[random] = true;
    }
}

