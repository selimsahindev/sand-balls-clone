using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] LevelManager levelManager;
    [SerializeField] bool isActive = false;

    private Transform parent;
    private Rigidbody rb;

    private void Start() {
        parent = this.transform.parent;
        rb = GetComponent<Rigidbody>();
        if (isActive) {
            rb.isKinematic = false;
        } else {
            rb.isKinematic = true;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("TruckBed")) {
            transform.parent = other.transform;
            levelManager.IncreaseBallCount();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("TruckBed")) {
            transform.parent = parent;
            levelManager.DecreaseBallCount();
        }
    }
}
