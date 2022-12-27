using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public List<GameObject> Bullets;

    public GameObject allBullets;

    public float firerate;

    float last_shoot_time;

    public int bullet_type;

    public int b_size_mult;
    public int b_speed;

    public GameObject player_obj_link;
    private Transform player_transform;

    public float shootXrange;

    public int enemy_id;

    private Animation scr_anim;

    public EffectsManager SoundEffectsScr;

    // Start is called before the first frame update
    void Start()
    {
        player_transform = player_obj_link.GetComponent<Transform>();
        //firerate = 0.5f;
        //b_speed = 70;
        if (enemy_id == 2)
        {
            scr_anim = GetComponent<Animation>();
        }
        if (enemy_id == 6)
        {
            scr_anim = GetComponent<Animation>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - last_shoot_time > 1.0f / firerate)
        {
            if (gameObject.transform.position[0] < player_transform.position[0] + 0.3f && player_transform.position[0] - 0.3f < gameObject.transform.position[0])
            {
                initBullet();
                //Debug.Log("FINE");
                last_shoot_time = Time.time;

                if (enemy_id == 2)
                {
                    scr_anim.needToPlay = true;
                }
                if (enemy_id == 6)
                {
                    scr_anim.needToPlay = true;
                }
            }
        }
    }

    void initBullet()
    {
        GameObject b = Instantiate(Bullets[bullet_type], transform.position, new Quaternion(0, 0, 0, 0), allBullets.transform);
        EnemyBullet scr = b.GetComponent<EnemyBullet>();
        scr.move = new Vector2(Random.Range(-shootXrange, shootXrange), -1);
        scr.speed = b_speed;

        SoundEffectsScr.indexSoundtoPlay.Add(1);
        SoundEffectsScr.indexVolumetoPlay.Add(1);
        //b.transform.rotation = Quaternion.Euler(0, 0, sh_st_rotation[p_now][i]);
    }
}
