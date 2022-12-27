using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPointPlus : MonoBehaviour
{
    public int points_to_plus;
    public int scorePlus;

    public EffectsManager SoundEffectsScr;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        Health scr_h = GetComponent<Health>();

        if (scr_h.hp <= 0)
        {
            PowerSpawn scr = GetComponentInParent<PowerSpawn>();
            scr.powerCounter += points_to_plus;
            scr.ShootSCounter += points_to_plus;
            scr.score += points_to_plus;

            scr.score += scorePlus;
            scr.kill_counter += 1;

            SoundEffectsScr.indexSoundtoPlay.Add(Random.Range(3, 8));
            SoundEffectsScr.indexVolumetoPlay.Add(1);
        }
    }
}