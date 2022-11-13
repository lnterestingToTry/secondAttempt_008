using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesManager : MonoBehaviour
{
    public GameObject Line;
    public List<GameObject> alllines;
    public GameObject allLinesGO;

    int linesNum;

    float spawnDelay;
    float lastSpawn;

    // Start is called before the first frame update
    void Start()
    {
        linesNum = 3;
        spawnDelay = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnDelay < Time.time - lastSpawn)
        {
            for (int i = 0; i <= linesNum; i += 1)
            {
                GameObject line = Instantiate(Line, new Vector3(Random.Range(-2.8f, 2.8f), Random.Range(transform.position[1], transform.position[1] + 12), Random.Range(-3, 5)), new Quaternion(0, 0, 0, 0), allLinesGO.transform);
            }

            linesNum = Random.Range(1, 3);
            lastSpawn = Time.time;
            
        }
    }
}
