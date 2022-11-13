using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_attenuation : MonoBehaviour
{
    public float activated;
    private UnityEngine.UI.Image SR;

    void Start()
    {
        SR = GetComponent<UnityEngine.UI.Image>();
        activated = 5;
    }

    void Update()
    {
        if (activated > 0)
        {
            SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, 1);
            activated -= 0.1f;
        }
        else
        {
            if (SR.color.a > 0.1f)
            {
                SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, SR.color.a - 0.01f);
            }
        }
    }

    public void Triggered()
    {
        activated = 5;
    }
}
