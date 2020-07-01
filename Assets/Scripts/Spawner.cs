using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject bird;
    private AudioSource source;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime = 1.0f;
    
    private float minSpawnHeight;
    private float maxSpawnHeight;
    
    private void Start() {
        var screenLimit = Camera.main.orthographicSize;
        minSpawnHeight = screenLimit * -1;
        maxSpawnHeight = screenLimit - 1; //minus one because sprite pivot is on bottom.
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            Vector3 spawnPos = new Vector3(transform.position.x, Random.Range(minSpawnHeight, maxSpawnHeight), 0f);
            Instantiate(bird, spawnPos, Quaternion.identity);
            
            //Play bird sound. Disable because it get's very annoying.
            float rand = Random.Range(0.9f, 1.4f);
            source.pitch = rand;
            //source.Play();

            //Add to Score
            GameStatus.GetInstance().AddToScore(1);
            
            timeBtwSpawn = startTimeBtwSpawn;
            if (startTimeBtwSpawn > minTime)
            {
                startTimeBtwSpawn -= decreaseTime;
            }
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
