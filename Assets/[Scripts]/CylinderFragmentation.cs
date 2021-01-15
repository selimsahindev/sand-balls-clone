using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderFragmentation : MonoBehaviour
{
    [SerializeField] MeshCollider[] colliders;

    private void Start() {
        foreach(MeshCollider col in colliders) {
            col.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("CylinderPiece")) {
            Destroy(other.gameObject);
        }
    }
}
