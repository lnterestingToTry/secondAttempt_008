using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class BackObj : MonoBehaviour
{
    private SpriteRenderer SR;
    public List<Sprite> images;
    public float speed;
    Rigidbody2D RB;
    public Light2D light_script;

    private float size;
    private float maxSize;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        RB = GetComponent<Rigidbody2D>();

        speed = Random.Range(30, 300);

        maxSize = 6;
        size = Random.Range(4, maxSize);
        light_script.pointLightInnerRadius = (light_script.pointLightInnerRadius * size) / maxSize;
        light_script.pointLightOuterRadius = (light_script.pointLightOuterRadius * size) / maxSize;

        light_script.intensity = (light_script.intensity * size / maxSize) * Random.Range(0, 2);

        transform.localScale = new Vector3(size, size, 0); 

        SR.sprite = images[Random.Range(0, images.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        RB.velocity = new Vector2(0, -speed * Time.deltaTime);
    }
}