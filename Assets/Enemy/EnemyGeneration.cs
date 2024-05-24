using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    public GameObject characterPoint;
    public GameObject enemy;
    [SerializeField] public GameObject boss;
    private bool canGenerate = true;
    private float timer;
    public float timeBetweenGeneration;
    private float targetTime = 0.0f;
    private float timeBetweenEnemyUpgrade = 0.0f;
    private int excalateHp = 10;
    private float excalateSpeed = 1f;

    void Update() {

        // Checks if it can generate enemies, if it can it will generate between 1 and 3 enemies.
        if (canGenerate) {
            canGenerate = false;
            int numEnemies = Random.Range(1, 4);
            for (int e = 0; e < numEnemies; e++){
                Vector3 spawnPosition = new Vector3(transform.position.x+e, transform.position.y+e, 0);
                GameObject eea = Instantiate(enemy, spawnPosition, Quaternion.identity);
                eea.gameObject.GetComponent<Enemy>().setMaxHp(excalateHp);
                eea.gameObject.GetComponent<Enemy>().setSpeed(excalateSpeed);
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

        // Every minute the enemies will gain more health and movement speed
        if (timeBetweenEnemyUpgrade >= 60.0f) 
        {
            timeBetweenEnemyUpgrade = 0.0f;
        }

        targetTime += Time.deltaTime;

        // Once 3 minutes have passed all the enemies will be destroy and the boss will be created
        if (targetTime >= 10.0f)
        {
            
            foreach (GameObject e in GameObject.FindGameObjectsWithTag("enemy"))
            {
                Destroy(e);
            }

            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, 0);
            Instantiate(boss, spawnPosition, Quaternion.identity);

            gameObject.SetActive(false);
            
        } 
    }
}
