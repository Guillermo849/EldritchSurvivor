using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BossAttacks : MonoBehaviour
{
    [SerializeField] GameObject characterPlayer;
    [SerializeField] GameObject rotationPoint;
    [SerializeField] GameObject laser;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject meteor;
    private Transform bulletTransform;
    private bool canAttack = false;
    private float TIMEBETWEENATTACKS = 10f;

    // Start is called before the first frame update
    void Start()
    {
        bulletTransform = GameObject.Find("BossBulletTransform").transform;
        StartCoroutine(WaitTillNextAttack());
    }

    // Update is called once per frame
    void Update()
    {
        rotationPoint.transform.RotateAround(transform.position, new Vector3(0, 0, 1), 10);

        if (canAttack) {
            canAttack = false;
            float distance = Vector3.Distance(characterPlayer.transform.position, transform.position);

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
        meteor.SetActive(true);
        meteor.transform.position = (Vector3) new Vector2(characterPlayer.transform.position.x, characterPlayer.transform.position.y);
        Vector3 originalSize = meteor.transform.localScale;
        for (int i = 0; i < 3; i++) {
            yield return new WaitForSeconds(0.3f);
            meteor.transform.localScale = new Vector3(originalSize.x-0.3f, originalSize.y-0.3f, 0);
        }
        meteor.transform.localScale = originalSize;
        meteor.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(0.7f);
        meteor.GetComponent<BoxCollider2D>().enabled = false;
        meteor.SetActive(false);
        StartCoroutine(WaitTillNextAttack());
    }
}
