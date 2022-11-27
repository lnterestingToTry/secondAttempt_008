using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushEnemy3 : MonoBehaviour
{
    private EnemyShooting scr_sh;
    private EnemyMovement scr_m;
    private Health scr_h;

    public GameObject particle;

    private GameObject player_obj_link;
    private Transform player_transform;

    private Animation scr_anim;

    public
    bool is_push;
    void Start()
    {
        scr_sh = GetComponent<EnemyShooting>();
        scr_m = GetComponent<EnemyMovement>();

        player_obj_link = scr_sh.player_obj_link;

        player_transform = player_obj_link.GetComponent<Transform>();

        scr_anim = GetComponent<Animation>();

        is_push = false;
    }

    void Update()
    {
        if (gameObject.transform.position[0] < player_transform.position[0] + 0.3f && player_transform.position[0] - 0.3f < gameObject.transform.position[0])
        {
            is_push = true;
            scr_anim.needToPlay = true;
            particle.SetActive(true);
        }
        if (is_push == true)
        {
            scr_m.speed += 0.1f;
            scr_m.move[0] = 0;
        }
    }
}
