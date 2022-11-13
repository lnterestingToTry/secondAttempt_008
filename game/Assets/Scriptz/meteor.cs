using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteor : MonoBehaviour
{
    private SpriteRenderer SR;
    public List<Sprite> images;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        Sprite sprite = images[Random.Range(0, images.Count - 1)];
        SR.sprite = sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
