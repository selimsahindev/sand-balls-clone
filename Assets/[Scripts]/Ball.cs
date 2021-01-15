using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Transform parent;

    private void Start() {
        parent = this.transform.parent;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("TruckBed")) {
            transform.parent = other.transform;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("TruckBed")) {
            transform.parent = parent;
        }
    }
}
