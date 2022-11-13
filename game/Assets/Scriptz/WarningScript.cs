using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningScript : MonoBehaviour
{
    public float delay_before_delate;

    public float delay;
    private float startTime;
    public GameObject Rocket;

    public Transform player_tr_link;

    private SpriteRenderer SR;
    public List<Sprite> anim_list;

    private float last_update;
    public float delay_per_frame;
    private int frame;

    public bool need_to_destroy;

    private bool triggered;
    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        startTime = Time.time;
        triggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Time.time - startTime > delay)
        //{
        //    GameObject enemy = Instantiate(Rocket, new Vector3(player_tr_link.position[0], 5, -1), new Quaternion(0, 0, 0, 0));
        //    Destroy(gameObject, delay_before_delate);
        //}

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
            if (triggered == false)
            {
                GameObject enemy = Instantiate(Rocket, new Vector3(player_tr_link.position[0], 5, -1), new Quaternion(0, 0, 0, 0), transform.parent.gameObject.transform);
                Destroy(gameObject, delay_before_delate);

                triggered = true;
            }
        }
        else
        {
            frame = 0;
        }
    }
}
