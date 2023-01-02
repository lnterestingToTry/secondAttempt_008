using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gm_scr;
    public bool anim_end;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (anim_end)
        {
            gm_scr._Start();
            gameObject.SetActive(false);
        }
    }
}
