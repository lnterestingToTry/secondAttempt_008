using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class TimeLeftIndicatorUI : MonoBehaviour
{
    public Shooting sh_scr;
    public Light2D light_script;
    private List<Color32> colors;
    public UI_attenuation attenuation_scr;

    public GameObject AnimToPlay;
    private bool anim_played;

    // Start is called before the first frame update
    void Start()
    {
        anim_played = false;
        colors = new List<Color32> { new Color32(154, 0, 0, 0), new Color32(2, 75, 0, 0) };
    }

    // Update is called once per frame
    void Update()
    {
        if (sh_scr.current_bullet > 0)
        {
            if (anim_played == false)
            {
                AnimToPlay.SetActive(true);
                anim_played = true;
            }

            if (sh_scr.current_bullet == 1)
            {
                light_script.color = colors[0];
            }
            else
            {
                light_script.color = colors[1];
            }

            attenuation_scr.Triggered();

            light_script.pointLightInnerAngle = 360f - 360f * (Time.time - sh_scr.currBulletInUpdateTime) / sh_scr.currBulletTime;
            light_script.pointLightOuterAngle = 360f - 360f * (Time.time - sh_scr.currBulletInUpdateTime) / sh_scr.currBulletTime + 4;
        }
        else
        {
            light_script.pointLightInnerAngle = 0;
            light_script.pointLightOuterAngle = 0;
            anim_played = false;
        }
    }
}
