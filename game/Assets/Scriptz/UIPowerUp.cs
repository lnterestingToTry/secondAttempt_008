using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class UIPowerUp : MonoBehaviour
{
    private UnityEngine.UI.Image SR;
    public List<List<Sprite>> anim_list;

    public List<Sprite> anim1;
    public List<Sprite> anim2;
    public List<Sprite> anim3;
    public List<Sprite> anim4;

    private float last_update;
    public float delay_per_frame;
    private int frame;

    public int current;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<UnityEngine.UI.Image>();
        //delay_per_frame = 0.2f;
        anim_list = new List<List<Sprite>> { anim1, anim2, anim3, anim4 };
    }

    // Update is called once per frame
    void Update()
    {
        if (frame < anim_list[current].Count)
        {
            if (Time.time - last_update > delay_per_frame)
            {
                last_update = Time.time;

                SR.sprite = anim_list[current][frame];
                frame += 1;
            }
        }
        else
        {
            frame = 0;
        }
    }
}
