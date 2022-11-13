using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animation : MonoBehaviour
{
    private SpriteRenderer SR;
    public List<Sprite> anim_list;

    private float last_update;
    public float delay_per_frame;
    private int frame;

    public float delay_before_delate;

    public bool need_to_destroy;
    public bool loop;
    public bool needToPlay;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        //delay_per_frame = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (frame < anim_list.Count && needToPlay)
        {
            if (Time.time - last_update > delay_per_frame)
            {
                last_update = Time.time;

                SR.sprite = anim_list[frame];
                frame += 1;

            }
        }
        else if(need_to_destroy == true)
        {
            Destroy(gameObject, delay_before_delate);
        }
        else if(loop == true)
        {
            frame = 0;
        }
        else if(needToPlay)
        {
            needToPlay = false;
        }
    }
}
