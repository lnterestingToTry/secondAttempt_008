using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplierMaskEffect : MonoBehaviour
{
    public GameObject mask;
    public RectTransform mask_transform, text_transform;
    public GameManager gm_scr;

    public GameObject updateAnim;

    public Text mult;
    private Text mult_sec;

    private float start_pos, text_tr_start_pos, pos_differ;

    // Start is called before the first frame update
    void Start()
    {
        text_transform = GetComponent<RectTransform>();
        mult_sec = GetComponent<Text>();

        start_pos = mask_transform.anchoredPosition[1];
        text_tr_start_pos = text_transform.anchoredPosition[1];
    }

    //-0.0001106262 //-101.5

    // Update is called once per frame
    void Update()
    {
        float difference = -102.3171f * gm_scr.multiplierIncrease / gm_scr.toMultiplierIncreaseBound;

        //mask_transform.anchoredPosition = new Vector2(mask_transform.anchoredPosition[0], mask_transform.anchoredPosition[1] + difference);
        //text_transform.anchoredPosition = new Vector2(text_transform.anchoredPosition[0], text_transform.anchoredPosition[1] - difference);

        if (Time.timeScale >= 0)
        {
            //mask_transform.anchoredPosition = new Vector2(mask_transform.anchoredPosition[0], mask_transform.anchoredPosition[1] - (difference * Time.timeScale));
            //text_transform.anchoredPosition = new Vector2(text_transform.anchoredPosition[0], text_transform.anchoredPosition[1] + (difference * Time.timeScale));
            mask_transform.anchoredPosition = new Vector2(mask_transform.anchoredPosition[0], difference );
            text_transform.anchoredPosition = new Vector2(text_transform.anchoredPosition[0], -difference );
        }

        if (gm_scr.multiplierIncrease >= gm_scr.toMultiplierIncreaseBound - 10)
        {
            mask_transform.anchoredPosition = new Vector2(mask_transform.anchoredPosition[0], start_pos);
            text_transform.anchoredPosition = new Vector2(text_transform.anchoredPosition[0], text_tr_start_pos);

            updateAnim.SetActive(true);
        }
        if (gm_scr.multiplierIncrease <= 0)
        {
            mult_sec.text = mult.text;
        }
    }
}
