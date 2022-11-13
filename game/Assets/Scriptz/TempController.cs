using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempController : MonoBehaviour
{
    public GameManager gm_script;

    Movement movement_script;
    Shooting shooting_script;
    public GameObject Bable;

    public GameObject bable_particle;

    public List<bool> tempNow; //b_speed; b_size; speed; bable;

    public List<float> delay;
    public List<float> actual;

    public List<bool> tempActivate;

    public GameObject UI_obj;
    public UIPowerUp UIPowerUp_scr;

    void Start()
    {
        movement_script = GetComponent<Movement>();
        shooting_script = GetComponent<Shooting>();

        delay = new List<float> {4, 5, 6, 4};
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
        UIPowerUp_scr.current = index;
        UI_obj.SetActive(true);

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
                Debug.Log("work1");
                break;

            case (1):
                shooting_script.b_size_mult = 1;
                Debug.Log("work2");
                break;

            case (2):
                movement_script.speed_mult = 1;
                Debug.Log("work3");
                break;

            case (3):
                Bable.SetActive(false);
                Debug.Log("work4");
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("2") && tempNow[3] == false) //enemy_bullet
        {
            gm_script.GameOver();
        }
        else if(collision.gameObject.CompareTag("2"))
        {
            GameObject bable_p = Instantiate(bable_particle, collision.gameObject.transform.position, new Quaternion(0, 0, 0, 0));
            Destroy(bable_p, 1f);

            Destroy(collision.gameObject);
        }
    }
}