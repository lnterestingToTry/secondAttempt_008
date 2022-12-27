using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int hp;
    public float multiplier;

    public GameObject expl;
    void Start()
    {
        if (multiplier > 0)
        {
            hp = (int)(hp * multiplier);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);

            //expl = Instantiate(expl, transform.position, new Quaternion(0, 0, 0, 0));
            //Destroy(expl, 1f);
        }
    }

    private void OnDestroy()
    {
        expl = Instantiate(expl, transform.position, new Quaternion(0, 0, 0, 0));
        Destroy(expl, 1f);
    }
}
