using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageAnim : MonoBehaviour
{
    public UnityEngine.UI.Image image;
    public List<Sprite> anim_list;

    private float last_update;
    public float delay_per_frame;
    private int frame;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<UnityEngine.UI.Image>();
        frame = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (frame < anim_list.Count)
        {
            if (Time.time - last_update > delay_per_frame)
            {
                last_update = Time.time;

                image.sprite = anim_list[frame];
                frame += 1;
            }
        }
        else
        {
            frame = 0;
        }
    }
}
