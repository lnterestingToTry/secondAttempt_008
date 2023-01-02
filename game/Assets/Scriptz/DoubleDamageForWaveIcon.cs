using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDamageForWaveIcon : MonoBehaviour
{
    private UnityEngine.UI.Image SR;
    public List<List<Sprite>> anim;

    public List<Sprite> anim1;
    public List<Sprite> anim2;
    public List<Sprite> anim3;
    public List<Sprite> anim4;
    public List<Sprite> anim5;

    public int current;

    private float last_update;
    public float delay_per_frame;
    private int frame;

    public bool need_to_DEactivate;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<UnityEngine.UI.Image>();
        anim = new List<List<Sprite>> { anim1, anim2, anim3, anim4, anim5 };
    }

    // Update is called once per frame
    void Update()
    {
        if (frame < anim[current].Count)
        {
            if (Time.time - last_update > delay_per_frame)
            {
                last_update = Time.time;

                SR.sprite = anim[current][frame];
                frame += 1;
            }
        }
        else
        {
            frame = 0;
            if (need_to_DEactivate)
            {
                gameObject.SetActive(false);
                SR.sprite = anim[current][frame];
            }
        }
    }
}


