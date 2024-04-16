using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class EnemyGeneration : MonoBehaviour
{
    public GameObject characterPoint;
    public GameObject enemy;
    private bool canGenerate = true;
    private float timer;
    public float timeBetweenGeneration;
    [SerializeField] public Transform centerPoint;

    //private Vector3 StartingPosition;
    void Start()
    {
       // StartingPosition = transform.position;
    }

    void Update() {
        transform.RotateAround(centerPoint.position, new Vector3(0, 0, 1), 10);

        if (canGenerate) {
            canGenerate = false;
            int numEnemies = Random.Range(1, 4);
            for (int e = 0; e < numEnemies; e++){
                Vector3 spawnPosition = new Vector3(transform.position.x+e, transform.position.y+e, 0);
                Instantiate(enemy, spawnPosition, Quaternion.identity);
            }    
        }

        if (!canGenerate) {
            timer += Time.deltaTime;
            if (timer > timeBetweenGeneration) {
                canGenerate = true;
                timer = 0;
            }
        }
    }
}
