using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMeteorits : MonoBehaviour
{
    public List<List<GameObject>> pointsToSpawnE;

    public List<GameObject> pointsToSpLeft;
    public List<GameObject> pointsToSpRight;
    public List<GameObject> pointsToSpCenter;

    public GameObject meteor;

    public GameObject GO_enemys;

    public List<List<int>> moveE;

    public float spawn_delay;
    public float last_spawn;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30;
        Time.timeScale = 1f;

        pointsToSpawnE = new List<List<GameObject>> { pointsToSpLeft, pointsToSpCenter, pointsToSpRight };

        moveE = new List<List<int>> { new List<int> { 0, 20 }, new List<int> { -20, 20 }, new List<int> { -20, 0 } };

        last_spawn = 0;
        spawn_delay = 6.3f;

    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 50) < 1)
        {
            new_meteor(Random.Range(1, 2));
        }

        //if (Time.time - last_spawn > spawn_delay)
        //{
        //    last_spawn = Time.time;
        //}
    }

    private void new_meteor(int to_spawn)
    {
        int side_to_spawn = Random.Range(0, 3);
        int spawn_point = Random.Range(0, pointsToSpawnE[side_to_spawn].Count);

        for (int i = 0; i <= to_spawn; i += 1)
        {
            GameObject meteorit = Instantiate(meteor, pointsToSpawnE[side_to_spawn][spawn_point].transform.position, new Quaternion(0, 0, 0, 0), GO_enemys.transform);

            EnemyMovement scr_m = meteorit.GetComponent<EnemyMovement>();
            Health scr_h = meteorit.GetComponent<Health>();

            //EnemyShooting scr_sh = meteorit.GetComponent<EnemyShooting>();

            scr_m.move = new Vector2(Random.Range(moveE[side_to_spawn][0],
                                                moveE[side_to_spawn][1]), Random.Range(45, 80));

            scr_h.multiplier = 0.2f;
            scr_m.speed = 1;
            //scr_sh.allBullets = allBullets;

            //Enemy_list.Add(meteorit);

            side_to_spawn = Random.Range(0, 3);
            spawn_point = Random.Range(0, pointsToSpawnE[side_to_spawn].Count);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("0"))
        {
            Destroy(collision.gameObject);
        }
    }
}
