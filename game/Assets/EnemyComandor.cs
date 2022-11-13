using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyComandor : MonoBehaviour
{
    public GameObject enemy;

    float spawnDelay;
    float lastSpawn;

    private GameObject player_obj_link;
    private GameObject allBullets;

    void Start()
    {
        spawnDelay = 3f;
        EnemyShooting scr_sh = GetComponent<EnemyShooting>();
        player_obj_link = scr_sh.player_obj_link;
        allBullets = scr_sh.allBullets;
}

    void Update()
    {
        if (Time.time - lastSpawn > spawnDelay)
        {
            GameObject e = Instantiate(enemy, new Vector3(transform.position[0], transform.position[1] + 0.0149f, -1.1f), new Quaternion(0, 0, 0, 0), transform.parent.gameObject.transform);

            EnemyMovement scr_m = e.GetComponent<EnemyMovement>();
            EnemyShooting scr_sh = e.GetComponent<EnemyShooting>();
            Health scr_h = e.GetComponent<Health>();

            scr_h.multiplier = GetComponent<Health>().multiplier;

            scr_m.move = new Vector2(Random.Range(-9, 9), Random.Range(-20, 30));
            scr_m.speed = 1;

            scr_sh.allBullets = allBullets;
            scr_sh.player_obj_link = player_obj_link;


            lastSpawn = Time.time;
        }
    }
}
