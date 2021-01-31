using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatGenerator : MonoBehaviour
{
    public bool generateRatsHerd;
    public Transform[] spawnPoints;
    public GameObject ratPrefab;

    private float currentTime = 0;
    private float waveTime = 1.5f;
    private int waveMultiplier = 1;

    void Start()
    {
        
    }

    void Update()
    {
        if(generateRatsHerd && waveMultiplier < 900)
        {
            if(currentTime > waveTime)
            {
                for(int i = 0; i < waveMultiplier; i++)
                {
                    Instantiate(ratPrefab, spawnPoints[Random.Range(0, spawnPoints.Length - 1)].position, ratPrefab.transform.rotation);
                }
                waveMultiplier *= 2;
                currentTime = 0;
            }
            currentTime += Time.deltaTime;
        }
    }
}
