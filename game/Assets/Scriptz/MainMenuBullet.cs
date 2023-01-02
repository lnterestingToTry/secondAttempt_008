using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBullet : MonoBehaviour
{
    //private Health scr_h;
    // Start is called before the first frame update
    void Start()
    {
        //Health scr_h = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("0"))
        {
            Destroy(gameObject);
            collision.GetComponent<Health>().hp -= Random.Range(1, 3);
        }
    }
}
