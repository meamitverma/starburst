using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject[] meteors; 
    public Transform meteorsHolder;
    public float minDelay = 0.3f, maxDelay = 0.7f;

    private float delay;

    // Start is called before the first frame update
    void Start()
    {
        delay = Random.Range(minDelay, maxDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if (delay <= 0f) {
            int meteor = Random.Range(0, meteors.Length);
            spawnMeteor(meteor);
            delay = Random.Range(minDelay, maxDelay);
        }
        delay -= Time.deltaTime;

    }

    void spawnMeteor(int m) {
        GameObject _meteor = Instantiate(meteors[m], transform.position, meteors[m].transform.rotation, meteorsHolder);
    }
}
