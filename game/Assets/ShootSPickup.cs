using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSPickup : MonoBehaviour
{
    private SpriteRenderer SR;
    private List<List<Sprite>> anim_list;

    public List<Sprite> anim1;
    public List<Sprite> anim2;
    public List<Sprite> anim3;
    public List<Sprite> anim4;
    public List<Sprite> anim5;

    private float last_update;
    public float delay_per_frame;
    private int frame;

    public float delay_before_delate;

    public bool need_to_destroy;

    private int shootSToPick;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        //delay_per_frame = 0.2f;
        anim_list = new List<List<Sprite>> { anim1, anim5, anim4, anim3, anim2 };
        shootSToPick = Random.Range(0, anim_list.Count);
    }

    // Update is called once per frame
    void Update()
    {
        if (frame < anim_list[shootSToPick].Count)
        {
            if (Time.time - last_update > delay_per_frame)
            {
                last_update = Time.time;

                SR.sprite = anim_list[shootSToPick][frame];
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
        Shooting scr = player.GetComponent<Shooting>();

        if (scr.p_now != shootSToPick)
        {
            scr.p_now = shootSToPick;
            scr.bulletUpgrade(5);
        }
        else
        {
            scr.bulletUpgrade(20);
        }

        //int random = Random.Range(0, 4);
        //Debug.Log(random);
        //scr.tempNow[random] = true;
    }
}
