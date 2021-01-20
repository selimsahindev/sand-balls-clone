﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] LevelManager levelManager;
    [SerializeField] bool isActive = false;

    private bool isPainted = false;
    private Transform parent;
    private Rigidbody rb;
    private Collider col;
    private Renderer ballRenderer;

    private void Start() {
        parent = this.transform.parent;
        rb = GetComponent<Rigidbody>();
        ballRenderer = GetComponent<Renderer>();

        if (isActive) {
            rb.isKinematic = false;
            PaintBall();
        } else {
            Invoke("SetKinematicToTrue", 0.5f);
        }

    }

    private void FixedUpdate() {
        if (isActive && !isPainted) {
            PaintBall();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("TruckBed")) {
            transform.parent = other.transform;
            rb.velocity = Vector3.zero;

            levelManager.IncreaseBallCount();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("TruckBed")) {
            transform.parent = parent;

            levelManager.DecreaseBallCount();
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("Ball")) {
            if (!isActive && collision.gameObject.GetComponent<Ball>().isActive) {
                isActive = true;
                rb.isKinematic = false;
            }
        }
    }

    private void SetKinematicToTrue() {
        rb.isKinematic = true;
    }

    private void PaintBall() {
        ballRenderer.material.color = Random.ColorHSV();
        isPainted = true;
    }
}
