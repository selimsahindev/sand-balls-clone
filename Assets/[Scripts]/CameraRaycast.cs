using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraRaycast : MonoBehaviour
{
    private Camera cam;
    private Ray ray;
    private RaycastHit hit;

    private void Start() {
        cam = this.GetComponent<Camera>();
    }

    private void FixedUpdate() {
        if (Input.GetMouseButton(0)) {
            DeformMesh();
        }
    }

    private void DeformMesh() {
        ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit)) {
            DeformPlane deformPlane = hit.transform.GetComponent<DeformPlane>();
            deformPlane.Deform(hit.point);
        }
    }
}
