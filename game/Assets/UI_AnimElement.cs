using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_AnimElement : MonoBehaviour
{
    private UnityEngine.UI.Image SR;
    public List<Sprite> anim;

    private float last_update;
    public float delay_per_frame;
    private int frame;

    public bool need_to_DEactivate;
    
    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<UnityEngine.UI.Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (frame < anim.Count)
        {
            if (Time.time - last_update > delay_per_frame)
            {
                last_update = Time.time;

                SR.sprite = anim[frame];
                frame += 1;

            }
        }
        else
        {
            frame = 0;
            if (need_to_DEactivate)
            {
                gameObject.SetActive(false);
                SR.sprite = anim[frame];
            }
        }


    }
}
