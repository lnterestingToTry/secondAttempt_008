using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy7AfterDeath : MonoBehaviour
{
    public GameObject after;
    public GameObject enemy;

    private EnemyShooting script_sh;
    private Health script_h;

    private void Start()
    {
        script_sh = GetComponent<EnemyShooting>();
        script_h = GetComponent<Health>();
    }

    private void OnDestroy()
    {
        if (script_h.hp <= 0)
        {
            Instantiate(after, gameObject.transform.position, new Quaternion(0, 0, 0, 0), transform.parent.gameObject.transform);

            spawnE(); spawnE(); spawnE();
        }
    }

    private void spawnE()
    {
        GameObject e = Instantiate(enemy, new Vector3(transform.position[0], transform.position[1] + 0.0149f, -1.1f), new Quaternion(0, 0, 0, 0), transform.parent.gameObject.transform);

        EnemyMovement scr_m = e.GetComponent<EnemyMovement>();
        EnemyShooting scr_sh = e.GetComponent<EnemyShooting>();
        Health scr_h = e.GetComponent<Health>();

        scr_h.multiplier = GetComponent<Health>().multiplier;

        scr_m.move = new Vector2(Random.Range(-9, 9), Random.Range(-10, 20));
        scr_m.speed = 1;

        scr_sh.allBullets = script_sh.allBullets;
        scr_sh.player_obj_link = script_sh.player_obj_link;

        Rigidbody2D RB = e.GetComponent<Rigidbody2D>();
        RB.velocity = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
    }
}
