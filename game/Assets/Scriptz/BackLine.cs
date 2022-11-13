using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackLine : MonoBehaviour
{
    private SpriteRenderer SR;
    public List<Sprite> images;
    public float speed;
    Rigidbody2D RB;

    float alphaMinus;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        RB = GetComponent<Rigidbody2D>();

        speed = Random.Range(500, 700);

        SR.sprite = images[Random.Range(0, images.Count)];

        alphaMinus = Random.Range(0.01f, 0.03f);
    }

    // Update is called once per frame
    void Update()
    {
        RB.velocity = new Vector2(0, -speed * Time.deltaTime);
        SR.color = new Color(255, 255, 255, SR.color.a - 0.04f);
    }
}
