using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("CylinderPiece")) {
            Destroy(other.gameObject);
        }
    }
}
