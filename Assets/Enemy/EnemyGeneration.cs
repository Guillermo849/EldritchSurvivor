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
    [SerializeField] public GameObject boss;
    private bool canGenerate = true;
    private float timer;
    public float timeBetweenGeneration;
    [SerializeField] public Transform centerPoint;
    private float targetTime = 0.0f;
    private float timeBetweenEnemyUpgrade = 0.0f;
    private int excalateHp = 15;

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
                GameObject eea = Instantiate(enemy, spawnPosition, Quaternion.identity);
                eea.gameObject.GetComponent<Enemy>().setMaxHp(excalateHp);
            }    
        }

        if (!canGenerate) {
            timer += Time.deltaTime;
            if (timer > timeBetweenGeneration) {
                canGenerate = true;
                timer = 0;
            }
        }
        
        timeBetweenEnemyUpgrade += Time.deltaTime;

        if (timeBetweenEnemyUpgrade >= 60.0f) 
        {
            excalateHp += 5;
            timeBetweenEnemyUpgrade = 0.0f;
            Debug.LogWarning("Enemy hp upraded");
        }

        targetTime += Time.deltaTime;

        if (targetTime >= 180.0f)
        {
            
            foreach (GameObject e in GameObject.FindGameObjectsWithTag("enemy"))
            {
                Destroy(e);
            }

            Debug.LogWarning("Enemigos eliminados");

            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, 0);
            Instantiate(boss, spawnPosition, Quaternion.identity);

            gameObject.SetActive(false);
            
        } 
    }
}
