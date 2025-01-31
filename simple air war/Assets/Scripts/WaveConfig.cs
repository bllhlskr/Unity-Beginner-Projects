﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName="Enemy Wawe Config")]
public class WaveConfig : ScriptableObject{

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed= 2f;



public GameObject GetEnemyPrefab(){return enemyPrefab; }
    public List<Transform> GetWayPoints() {
        var waveWayPoints = new List<Transform>();
        foreach(Transform child in pathPrefab.transform)
        {
            waveWayPoints.Add(child);
        }


        return waveWayPoints;


        
    }
    public float GettimeBetweenSpawns() { return timeBetweenSpawns; }
    public float GetspawnRandomFactor() { return spawnRandomFactor; }
    public int GetnumberOfEnemies() { return numberOfEnemies; }
    public float GetmoveSpeed() { return moveSpeed; }

}
