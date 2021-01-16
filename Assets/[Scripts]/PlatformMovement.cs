using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] float minY = -10f;
    [SerializeField] LevelManager levelManager;

    private Vector3 startingPos;

    private void Start() {
        startingPos = transform.position;
    }

    private void FixedUpdate() {
        MovePlatform();

        if (transform.position.y <= minY) {
            levelManager.isPlatformDown = true;
        } else {
            levelManager.isPlatformDown = false;
        }
    }

    private void MovePlatform() {
        int ballsInTruck = levelManager.GetBallCount();

        if (ballsInTruck > 0) {
            float step = ballsInTruck * Time.fixedDeltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(startingPos.x, minY, startingPos.z), step);
        } else {
            transform.position = Vector3.MoveTowards(transform.position, startingPos, 10 * Time.fixedDeltaTime);
        }
    }
}
