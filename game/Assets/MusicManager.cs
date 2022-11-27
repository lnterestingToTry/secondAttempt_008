using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public List<AudioClip> playlist;

    int current_clip;
    float clip_lenght;

    public AudioSource AS;
    //float playback_time;

    void Start()
    {
        //current_clip = Random.Range(0, playlist.Count);
        //clip_lenght = playlist[current_clip].length;
        new_clip();
    }

    void Update()
    {
        if (AS.time == clip_lenght)
        {
            new_clip();
        }
    }

    void new_clip()
    {
        current_clip = Random.Range(0, playlist.Count);
        clip_lenght = playlist[current_clip].length;
        AS.clip = playlist[current_clip];
        AS.Play();
    }
}
