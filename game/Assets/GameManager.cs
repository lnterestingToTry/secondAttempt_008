using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    private Shooting player_sh_scr;

    public List<GameObject> Enemy_list;
    public List<GameObject> Enemy_prefabs;

    public List<GameObject> EnemyForWave;

    public GameObject meteor;

    public GameObject allBullets;

    public List<List<GameObject>> pointsToSpawnE;

    public List<GameObject> pointsToSpLeft;
    public List<GameObject> pointsToSpRight;
    public List<GameObject> pointsToSpCenter;

    public List<List<int>> moveE;

    public GameObject GO_enemys;
    public PowerSpawn PowerSpawn_scr;


    private bool game_paused;
    public GameObject PauseCanvas;
    public GameObject ToMainMenuCanvas;

    public GameObject AfterGameCanvas;
    public Text scoreText;
    public Text killCounterText;


    public bool game_stopd;
    //public GameObject NewWaveCanvas;
    //public Animator NewWaveInfAnim1, NewWaveInfAnim2;
    private BeforeWaveAnim beforeWaveAnim;


    public float spawn_delay;
    public float last_spawn;
    public int to_spawn;

    public List<GameObject> new_wave_warning;
    public GameObject WarningRprefab;

    public float multiplier;
    public int multiplierIncrease, toMultiplierIncreaseBound;

    public EffectsManager SoundEffectsScr;
    public MusicManager MusicManagerScr;

    public Text multiplierLabel;

    public SettingsKeeper settingsKeeper_scr;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30;
        Time.timeScale = 1f;

        player_sh_scr = player.GetComponent<Shooting>();

        last_spawn = 0;
        spawn_delay = 4.8f;
        to_spawn = 3;

        pointsToSpawnE = new List<List<GameObject>> { pointsToSpLeft, pointsToSpCenter, pointsToSpRight };

        moveE = new List<List<int>> { new List<int> {0,  20}, new List<int> { -20, 20 }, new List<int> { -20, 0 } };
        Random.InitState(Time_seed());

        beforeWaveAnim = GetComponent<BeforeWaveAnim>();

        multiplier = 0.8f;
        multiplierIncrease = 0;
        toMultiplierIncreaseBound = 1000;

        game_stopd = true;
        //mult_update();

        //multiplierChanged(0);
    }

    public void _Start()
    {
        game_stopd = false;
        mult_update();
        multiplierChanged(0);
    }

    void Update()
    {
        if (Time.timeScale != 0 && game_stopd == false)
        {
            if (to_spawn > 0)
            {
                new_enemy(to_spawn);
                to_spawn = 0;
            }

            if (Random.Range(0, 300) < 1)
            {
                new_meteor(Random.Range(1, 2));
            }

            if (Random.Range(0, 250) < 1 || (player.transform.position[0] < -2.5 || player.transform.position[0] > 2.5))
            {
                new_rocket();
            }

            if (Time.time - last_spawn > spawn_delay)
            {
                last_spawn = Time.time;
                to_spawn = 3;
            }

            multiplierIncrease += (int)(1f * Time.timeScale);
        }

        if (multiplierIncrease >= toMultiplierIncreaseBound)
        {
            game_stopd = true;
            if (GO_enemys.transform.childCount <= 0 && allBullets.transform.childCount <= 0)
            {
                //Debug.Log("WOORK");
                mult_update();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape)) //&& game_over != true)
        {
            //Debug.Log("PAUSED");

            if (game_paused == false)
            {
                OnPause();
            }
            else
            {
                OffPause();
            }
            //Debug.Log(Time.timeScale);
            //Time.timeScale = 0f;
        }
    }

    private void mult_update()
    {
        multiplierIncrease = 0;
        multiplierChanged(0.2f);

        game_stopd = true;
        EnemyForWaveListGenerate();
        //DoubleDamageForWaveListGenerate();
    }

    private void EnemyForWaveListGenerate()
    {
        EnemyForWave = new List<GameObject> { };
        List<int> indexsE = new List<int> { };

        for (int i = 0; i <= 6; i += 1)
        {
            indexsE.Add(i);
        }

        for (int i = 0; i <= 3; i += 1)
        {
            int r = Random.Range(0, 6 - i);
            indexsE.Remove(r);
        }

        for (int i = 0; i <= 2; i += 1)
        {
            EnemyForWave.Add(Enemy_prefabs[indexsE[i]]);
        }


        List<int> indexsD = new List<int> { };

        for (int i = 0; i <= 4; i += 1)
        {
            indexsD.Add(i);
        }

        for (int i = 0; i <= 1; i += 1)
        {
            int r = Random.Range(0, 4 - i);
            indexsD.Remove(r);
        }
        player_sh_scr.sh_st_double_damage = indexsD;


        beforeWaveAnim.BeforeWavePlay(indexsE, indexsD, PowerSpawn_scr.score);
    }

    private void new_enemy(int to_spawn)
    {
        int side_to_spawn = Random.Range(0, 3);
        int spawn_point = Random.Range(0, pointsToSpawnE[side_to_spawn].Count);

        for (int i = 0; i < to_spawn; i += 1)
        {
            GameObject enemy = Instantiate(EnemyForWave[Random.Range(0, EnemyForWave.Count)], pointsToSpawnE[side_to_spawn][spawn_point].transform.position, new Quaternion(0, 0, 0, 0), GO_enemys.transform);

            EnemyMovement scr_m = enemy.GetComponent<EnemyMovement>();
            EnemyShooting scr_sh = enemy.GetComponent<EnemyShooting>();
            Health scr_h = enemy.GetComponent<Health>();
            PowerPointPlus scr_ppp = enemy.GetComponent<PowerPointPlus>();

            scr_h.multiplier = multiplier;

            scr_m.move = new Vector2(Random.Range(moveE[side_to_spawn][0],
                                                moveE[side_to_spawn][1]), Random.Range(-70, -45));
            //scr_m.speed = 1;

            scr_sh.allBullets = allBullets;
            scr_sh.player_obj_link = player;
            scr_sh.SoundEffectsScr = SoundEffectsScr;

            scr_ppp.SoundEffectsScr = SoundEffectsScr;
            scr_ppp.scorePlus = System.Convert.ToInt32(scr_ppp.scorePlus * multiplier);
            //Enemy_list.Add(enemy);

            side_to_spawn = Random.Range(0, 3);
            spawn_point = Random.Range(0, pointsToSpawnE[side_to_spawn].Count);

        }
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

            scr_h.multiplier = multiplier;
            //EnemyShooting scr_sh = meteorit.GetComponent<EnemyShooting>();

            scr_m.move = new Vector2(Random.Range(moveE[side_to_spawn][0],
                                                moveE[side_to_spawn][1]), Random.Range(-80, -45));
            scr_m.speed = 1;
            //scr_sh.allBullets = allBullets;

            //Enemy_list.Add(meteorit);

            side_to_spawn = Random.Range(0, 3);
            spawn_point = Random.Range(0, pointsToSpawnE[side_to_spawn].Count);
        }
    }

    private void new_rocket()
    {
        int side_to_spawn = Random.Range(0, 3);
        int spawn_point = Random.Range(0, pointsToSpawnE[side_to_spawn].Count);

        for (int i = 0; i <= to_spawn; i += 1)
        {
            GameObject rocket = Instantiate(WarningRprefab, new Vector3(player.transform.position[0], 3.2f, -1), new Quaternion(0, 0, 0, 0), GO_enemys.transform);

            EnemyMovement scr_m = rocket.GetComponent<EnemyMovement>();
            WarningScript scr_warn = rocket.GetComponent<WarningScript>();

            SoundEffectsScr.indexSoundtoPlay.Add(2);
            SoundEffectsScr.indexVolumetoPlay.Add(1);

            scr_warn.player_tr_link = player.transform;

            //EnemyShooting scr_sh = meteorit.GetComponent<EnemyShooting>();

            //scr_m.move = new Vector2(Random.Range(moveE[side_to_spawn][0],
            //                                    moveE[side_to_spawn][1]), Random.Range(-60, -45));
            //scr_sh.allBullets = allBullets;

            //Enemy_list.Add(rocket);

            //side_to_spawn = Random.Range(0, 3);
            //spawn_point = Random.Range(0, pointsToSpawnE[side_to_spawn].Count);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("0")) //enemy
        {
            //Destroy(collision.gameObject);
            //Enemy_list.Remove(collision.gameObject);
            removeEnemy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("1")) //bullet
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("5")) //backLine
        {
            Destroy(collision.gameObject);
        }
    }

    public void removeEnemy(GameObject enemy)
    {
        Destroy(enemy, 1f);
        //Enemy_list.Remove(enemy);
    }

    public void OnPause()
    {
        game_paused = true;
        Time.timeScale = 0f;
        PauseCanvas.SetActive(true);
    }

    public void OffPause()
    {
        game_paused = false;
        Time.timeScale = 1;
        PauseCanvas.SetActive(false);
    }

    public void OnToMainMenuQuestion()
    {
        ToMainMenuCanvas.SetActive(true);
        PauseCanvas.SetActive(false);
    }

    public void OffToMainMenuQuestion()
    {
        ToMainMenuCanvas.SetActive(false);
        PauseCanvas.SetActive(true);
    }

    public void GameOver(int score, int kill_counter)
    {
        Time.timeScale = 0.1f;
        game_stopd = true;

        AfterGameCanvas.SetActive(true);

        scoreText.text = score.ToString();
        if (settingsKeeper_scr.record_score < score)
        {
            settingsKeeper_scr.record_score = score;
            settingsKeeper_scr.SaveData();
        }

        killCounterText.text = kill_counter.ToString();

        player.GetComponent<Movement>().speed_mult = 0;
        allBullets.SetActive(false);

        SoundEffectsScr.indexSoundtoPlay = new List<int> { };
        SoundEffectsScr.indexVolumetoPlay = new List<float> { };
        SoundEffectsScr.gameObject.GetComponent<AudioSource>().volume = 0f;

        MusicManagerScr.gameOver();
    }

    public void afterGameOver()
    {
        Time.timeScale = 1F;
    }

    public static int Time_seed()
    {
        return System.DateTime.UtcNow.GetHashCode();
    }

    public void multiplierChanged(float value)
    {
        multiplier += value;
        multiplierLabel.text = "X" + multiplier.ToString();
    }
}
