using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackObj2 : MonoBehaviour
{
    private SpriteRenderer SR;
    public List<List<Sprite>> images;
    public float speed;
    Rigidbody2D RB;

    public List<Sprite> an1;
    public List<Sprite> an2;
    public List<Sprite> an3;
    public List<Sprite> an4;
    public List<Sprite> an5;
    //public List<Sprite> an6;

    private float size;
    private float maxSize;

    private float last_update;
    public float delay_per_frame;
    private int frame;

    public List<int> rot;

    int an;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        RB = GetComponent<Rigidbody2D>();

        speed = Random.Range(30, 150);

        maxSize = 10;
        size = Random.Range(4, maxSize);

        transform.localScale = new Vector3(size, size, 0);

        images = new List<List<Sprite>> {an2, an3, an4, an5, an1};
        an = Random.Range(0, Random.Range(0, images.Count+1));

        rot = new List<int> {0, 90, 180, 270};

        transform.rotation = new Quaternion(0,0,rot[Random.Range(0, rot.Count)], 0);

        SR.sprite = images[an][frame];
    }

    // Update is called once per frame
    void Update()
    {
        RB.velocity = new Vector2(0, -speed * Time.deltaTime);

        if (frame < images[an].Count)
        {
            if (Time.time - last_update > delay_per_frame)
            {
                last_update = Time.time;

                SR.sprite = images[an][frame];
                frame += 1;
            }
        }
        else
        {
            frame = 0;
        }
    }
}