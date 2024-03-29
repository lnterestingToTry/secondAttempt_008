﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempController : MonoBehaviour
{
    public GameManager gm_script;
    public PowerSpawn PowerSpawn_scr;


    Movement movement_script;
    Shooting shooting_script;
    public GameObject Bable;

    public GameObject bable_particle;

    public List<bool> tempNow; //b_speed; b_size; speed; bable;

    public List<float> delay;
    public List<float> actual;

    public List<bool> tempActivate;

    public GameObject UI_obj;
    public UnityEngine.UI.Image UI_image;
    public UIPowerUp UIPowerUp_scr;

    public EffectsManager SoundEffectsScr;

    void Start()
    {
        movement_script = GetComponent<Movement>();
        shooting_script = GetComponent<Shooting>();

        UI_image = UI_obj.GetComponent<UnityEngine.UI.Image>();

        delay = new List<float> {3, 4, 5, 3};
        actual = new List<float> { 0, 0, 0, 0 };

        tempNow = new List<bool> {false, false, false, false };
        tempActivate = new List<bool> {false, false, false, false };
    }

    void Update()
    {
        for(int i = 0; i < tempNow.Count; i += 1)
        {
            if(tempNow[i] == true)
            {
                actual[i] += 0.01f * Time.timeScale;
                Debug.Log(1f * actual[i] / delay[i]);
                UI_image.color = new Color(255,255,255, 1f - (1f * actual[i] / delay[i]));

                if (actual[i] > delay[i])
                {
                    tempNow[i] = false;
                    tempActivate[i] = false;
                    actual[i] = 0;
                    DEactivate(i);
                    Debug.Log("work");
                }

                else if(tempActivate[i] == false)
                {
                    tempActivate[i] = true;
                    activate(i);
                }
            }
        }
    }

    void activate(int index)
    {
        for(int i = 0; i < tempNow.Count; i += 1)
        {
            if (i != index)
            {
                DEactivate(i);
                tempNow[i] = false;
                tempActivate[i] = false;
                actual[i] = 0;
            }
        }

        UIPowerUp_scr.current = index;
        UI_obj.SetActive(true);

        SoundEffectsScr.indexSoundtoPlay.Add(0);
        SoundEffectsScr.indexVolumetoPlay.Add(1);

        switch (index)
        {
            case(0):
                shooting_script.b_speed_mult = 2;
                break;

            case (1):
                shooting_script.b_size_mult = 2;
                break;

            case (2):
                movement_script.speed_mult = 2;
                break;

            case (3):
                Bable.SetActive(true);
                break;
        }
    }

    void DEactivate(int index)
    {
        //UIPowerUp_scr.current = index;
        UI_obj.SetActive(false);

        switch (index)
        {
            case (0):
                shooting_script.b_speed_mult = 1;
                //Debug.Log("work1");
                break;

            case (1):
                shooting_script.b_size_mult = 1;
                //Debug.Log("work2");
                break;

            case (2):
                movement_script.speed_mult = 1;
                //Debug.Log("work3");
                break;

            case (3):
                Bable.SetActive(false);
                //Debug.Log("work4");
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("2") && tempNow[3] == false) //enemy_bullet
        {
            SoundEffectsScr.indexSoundtoPlay.Add(Random.Range(3, 8));
            SoundEffectsScr.indexVolumetoPlay.Add(1);
            gm_script.GameOver(PowerSpawn_scr.score, PowerSpawn_scr.kill_counter);
        }
        if (collision.gameObject.CompareTag("0") && tempNow[3] == false) //enemy
        {
            SoundEffectsScr.indexSoundtoPlay.Add(Random.Range(3, 8));
            SoundEffectsScr.indexVolumetoPlay.Add(1);
            gm_script.GameOver(PowerSpawn_scr.score, PowerSpawn_scr.kill_counter);

            //collision.gameObject.GetComponent<Health>().hp = 0;
        }
        if (collision.gameObject.CompareTag("2") && tempNow[3] == true)
        {
            GameObject bable_p = Instantiate(bable_particle, collision.gameObject.transform.position, new Quaternion(0, 0, 0, 0));
            Destroy(bable_p, 1f);

            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("0") && tempNow[3] == true)
        {
            GameObject bable_p = Instantiate(bable_particle, collision.gameObject.transform.position, new Quaternion(0, 0, 0, 0));
            Destroy(bable_p, 1f);
            DEactivate(3);

            collision.gameObject.GetComponent<Health>().hp = 0;
        }
    }
}