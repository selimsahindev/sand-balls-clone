﻿using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float minHeight = 3f;
    [SerializeField] float smoothTime = 0.3F;

    private LevelManager levelManager;
    private GameObject[] ballsInLevel;
    private Vector3 velocity = Vector3.zero;
    private Vector3 cameraOffset = Vector3.zero;
    private float lowestBallHeight;
    private float targetHeight;

    #region Singleton
    public static CameraController instance = null;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    private void Start() {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        ballsInLevel = levelManager.ballsInLevel;
        lowestBallHeight = transform.position.y;
        cameraOffset = transform.position;
        targetHeight = transform.position.y;
    }

    private void LateUpdate() {
        MoveCamera();
    }

    private void MoveCamera() {
        if (transform.position.y <= minHeight) {
            targetHeight = minHeight;
        } else {
            for (int i = 0; i < ballsInLevel.Length; i++) {
                if (ballsInLevel[i].GetComponent<Ball>().isActive && ballsInLevel[i].transform.position.y < lowestBallHeight) {
                    lowestBallHeight = ballsInLevel[i].transform.position.y;
                    targetHeight = lowestBallHeight;
                }
            }
        }
        // Define a target position above and behind the target transform
        Vector3 targetPosition = new Vector3(cameraOffset.x, targetHeight, cameraOffset.z);

        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
