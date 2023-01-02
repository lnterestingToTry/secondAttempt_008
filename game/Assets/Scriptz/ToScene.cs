using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToScene : MonoBehaviour
{
    public SceneChanger sc_scr;
    public int sceneIndex;
    public bool anim_end;
    public Animation animComponent;

    // Start is called before the first frame update
    void Start()
    {
        //animComponent = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim_end)
        {
            sc_scr.ChangeScene(sceneIndex);
        }
    }
}
