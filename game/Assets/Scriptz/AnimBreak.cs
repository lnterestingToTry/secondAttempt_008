using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimBreak : MonoBehaviour
{
    private float start_posx;
    public BeforeWaveAnim bwa_scr;
    private RectTransform rect;

    void Start()
    {
        start_posx = GetComponent<RectTransform>().anchoredPosition[0];
        rect = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (rect.anchoredPosition[0] <= -start_posx)
        {
            bwa_scr.anim_end = true;
        }
    }
}
