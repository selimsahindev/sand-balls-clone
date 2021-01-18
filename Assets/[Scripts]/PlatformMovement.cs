using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Lumin;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] float moveSpeedFactor = 1f;
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
            float step = ballsInTruck * moveSpeedFactor * Time.fixedDeltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(startingPos.x, minY, startingPos.z), step);
        } else {
            float step = 10 * moveSpeedFactor * Time.fixedDeltaTime;
            transform.position = Vector3.MoveTowards(transform.position, startingPos, step);
        }
    }
}
