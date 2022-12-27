using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforeWaveAnim : MonoBehaviour
{
    public bool anim_end;
    public GameObject NewWaveCanvas;
    public Animator NewWaveInfAnim1;
    public UnityEngine.UI.Text score;

    public List<ShipsForWaveIcon> shipsImgs;
    public List<DoubleDamageForWaveIcon> DamageImgs;

    private GameManager Game_Manager;
    // Start is called before the first frame update
    void Start()
    {
        Game_Manager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim_end == true)
        {
            AfterWaveUpdate();
        }
    }
    public void BeforeWavePlay(List<int> enemys, List<int> damage, int current_score)
    {
        NewWaveCanvas.SetActive(true);

        for (int i = 0; i <= 2; i += 1)
        {
            shipsImgs[i].current = enemys[i];
        }

        for (int i = 0; i <= 1; i += 1)
        {
            DamageImgs[i].current = damage[i];
        }

        score.text = current_score.ToString();
    }

    private void AfterWaveUpdate()
    {
        NewWaveCanvas.SetActive(false);
        Game_Manager.game_stopd = false;
        anim_end = false;
    }
}
