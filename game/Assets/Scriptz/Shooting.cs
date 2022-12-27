using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public List<GameObject> bullets;
    public int current_bullet;
    public float currBulletTime, currBulletInUpdateTime;

    public GameObject allBullets;

    public GameManager gameManager_scr;

    public List<List<GameObject>> points;
    public List<GameObject> p1;
    public List<GameObject> p2;
    public List<GameObject> p3;
    public List<GameObject> p4;
    public List<GameObject> p5;

    public List<int> sh_st_speed; //shoot_style_bullets_speed
    public List<int> sh_st_damage;
    public List<int> sh_st_double_damage;

    public List<float> sh_st_firerate;

    public List<List<int>> sh_st_rotation;

    float last_shoot_time;

    public int p_now;

    public int b_size_mult;
    public int b_speed_mult;

    private List<List<Vector2>> shoot_style;

    public UIshootStyle UIanim;

    public EffectsManager SoundEffectsScr;
    public float volume;

    // Start is called before the first frame update
    void Start()
    {
        sh_st_speed = new List<int> {90, 50, 30, 60, 60};
        sh_st_damage = new List<int> {2, 2, 2, 2, 2};

        sh_st_firerate = new List<float> {6, 3, 2, 4, 3 };

        shoot_style = new List<List<Vector2>> { new List<Vector2> { new Vector2(0, 1) },
        new List<Vector2> { new Vector2(-1, 1), new Vector2(0, 1), new Vector2(1, 1) },
        new List<Vector2> { new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0), new Vector2(1, -1), new Vector2(0, -1), new Vector2(-1, -1), new Vector2(-1, 0), new Vector2(-1 , 1) },
        new List<Vector2> { new Vector2(0, 1), new Vector2(1, 0), new Vector2(0, -1), new Vector2(-1, 0) },
        new List<Vector2> { new Vector2(-2, 1), new Vector2(-1, 1), new Vector2(0, 1), new Vector2(1, 1), new Vector2(2, 1) }
        };

        sh_st_rotation = new List<List<int>> {new List<int> {0}, 
                                              new List<int> {30, 0, -30 },
                                              new List<int> {0, -45, -90, -135, -180, -225, -270, -315 },
                                              new List<int> {0, -90, -180, -270},
                                              new List<int> {65, 50, 0, -50, -65 }};



        points = new List<List<GameObject>> {p1, p2, p3, p4, p5 };

        currBulletTime = 10;
        currBulletInUpdateTime = 0;
        volume = 1;
        //p_now = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager_scr.GO_enemys.transform.childCount > 0 || gameManager_scr.game_stopd == false)
        {
            if (Time.time - last_shoot_time > 1 / sh_st_firerate[p_now] && Time.timeScale != 0)
            {
                if (Input.GetMouseButton(0))
                {
                    for (int i = 0; i < points[p_now].Count; i += 1)
                    {
                        initBullet(i);
                    }
                    last_shoot_time = Time.time;

                    if (volume >= 0.1f)
                    {
                        volume -= 0.05f;
                    }
                }
                else
                {
                    volume = 1;
                }
            }
        }

        if (current_bullet > 0)
        {
            if (Time.time - currBulletInUpdateTime > currBulletTime)
            {
                current_bullet -= 1;
                currBulletInUpdateTime = Time.time;
            }
        }

        UIanim.current = p_now;
    }

    void initBullet(int i)
    {
        GameObject b = Instantiate(bullets[current_bullet], points[p_now][i].transform.position, new Quaternion(0, 0, 0, 0), allBullets.transform);
        Bullet scr = b.GetComponent<Bullet>();
        scr.move = shoot_style[p_now][i];
        scr.damage = sh_st_damage[p_now] * b_size_mult * (current_bullet+1);

        if (p_now == sh_st_double_damage[0] || p_now == sh_st_double_damage[1])
        {
            scr.damage = scr.damage * 2;
        }

        scr.speed = sh_st_speed[p_now] * b_speed_mult;
        b.transform.localScale *= b_size_mult;

        b.transform.rotation = Quaternion.Euler(0, 0, sh_st_rotation[p_now][i]);

        SoundEffectsScr.indexSoundtoPlay.Add(1);
        SoundEffectsScr.indexVolumetoPlay.Add(volume / (p_now + 1f));
    }

    public void bulletUpgrade(float time)
    {
        currBulletTime = time;
        if (current_bullet < 2)
        {
            current_bullet += 1;
            currBulletInUpdateTime = Time.time;
        }
        else
        {
            currBulletInUpdateTime = Time.time;
        }
    }
}