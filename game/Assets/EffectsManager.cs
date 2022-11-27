using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    public List<AudioClip> sounds;
    public float volume;
    public List<int> indexSoundtoPlay;
    public List<float> indexVolumetoPlay;

    public AudioSource AS;

    void Start()
    {
        volume = GetComponent<AudioSource>().volume;
    }


    void Update()
    {
        for(int i = 0; i < indexSoundtoPlay.Count; i += 1)
        {
            AS.PlayOneShot(sounds[indexSoundtoPlay[i]] ,volume * indexVolumetoPlay[i]);
        }
        indexSoundtoPlay = new List<int> { };
        indexVolumetoPlay = new List<float> { };
    }
}
