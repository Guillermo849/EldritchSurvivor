using System.Collections;
using UnityEngine;

public class RotationGenerator : MonoBehaviour
{
    [SerializeField] public Transform centerPoint;
    private float gameTime;

    private float rotateSpeed = 1;

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Rotate());
    }
    private IEnumerator Rotate() {
        transform.RotateAround(centerPoint.position, new Vector3(0, 0, 1), rotateSpeed);
        yield return new WaitForSeconds(0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "barrier") {
            rotateSpeed *= -1;
        }
    }
}
