using System.Collections;
using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    private GameObject characterPlayer;
    [SerializeField] GameObject rotationPoint;
    [SerializeField] GameObject laser;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject meteor;
    private Transform bulletTransform;
    private bool canAttack = false;
    private float TIMEBETWEENATTACKS = 1.5f;

    // When the boss is iniciated it will locate player character and the boss bullet transform 
    void Start()
    {
        characterPlayer = GameObject.Find("PlayerCharacter");
        bulletTransform = GameObject.Find("BossBulletTransform").transform;
        StartCoroutine(WaitTillNextAttack());
    }

    // Once per frame the gameobject that generates the bullets will rotate around the BOSS.
    // It will choose at random one attack every 1.5 seconds, depending on the distance between 
    // the BOSS and the player character it will choose:
    //      Laser or Air attack
    //      Shoot or Air attack
    void Update()
    {
        rotationPoint.transform.RotateAround(transform.position, new Vector3(0, 0, 1), 10);

        if (canAttack) {
            canAttack = false;
            float distance = Vector3.Distance(
                characterPlayer.transform.position, 
                transform.position);

            if (Random.Range(1, 3) == 1) {
                StartCoroutine(AirAttack());
            } else {
                if (distance <= 5) {
                    StartCoroutine(Laser());
                } else {
                    StartCoroutine(Shoot());
                }
            }
        }
    }

    private IEnumerator WaitTillNextAttack(){
        yield return new WaitForSeconds(TIMEBETWEENATTACKS);
        canAttack = true;
    }

    private IEnumerator Shoot(){
        for (int b = 0; b < 150; b++){
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.05f);
        }
        StartCoroutine(WaitTillNextAttack());
    }

    private IEnumerator Laser() {
        laser.SetActive(true);
        
        // The position of where the laser spawns will be determined if the player is above or below it.
        Vector3 player_relative_to_boss = transform.position - characterPlayer.transform.position;
        Vector3 laserPosition = laser.transform.localPosition;
        if (player_relative_to_boss.y < 0) {
            laser.transform.localPosition = new Vector3 (laserPosition.x, -Mathf.Abs(laserPosition.y), 0);
        } else {
            laser.transform.localPosition = new Vector3 (laserPosition.x, Mathf.Abs(laserPosition.y), 0);
        }

        yield return new WaitForSeconds(1);
        for (int b = 0; b < 180; b++){
            laser.transform.RotateAround(transform.position, new Vector3(0, 0, 1), 2);
            yield return new WaitForSeconds(0.02f);
        }
        laser.SetActive(false);
        StartCoroutine(WaitTillNextAttack());
    }
    private IEnumerator AirAttack(){
        for (int m = 0; m < 4; m++) {
            GameObject mtr = Instantiate(meteor, characterPlayer.transform.position, Quaternion.identity);
            mtr.SetActive(true);
            mtr.transform.localScale = new Vector3(6f, 6f, 0);
            yield return new WaitForSeconds(1f);
        }
        StartCoroutine(WaitTillNextAttack());
    }
}
