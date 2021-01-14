using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeformPlane : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] float power;

    [Tooltip("For expanding the inner circle")]
    [SerializeField] float scaleFactor = 0f;

    [SerializeField] Transform cylinder;

    private Camera cam;
    private Ray ray;
    private RaycastHit hit;

    private MeshFilter meshFilter;
    private Mesh mesh;
    Vector3[] vertices;

    private void Start() {
        cam = Camera.main;
        meshFilter = GetComponent<MeshFilter>();
        mesh = meshFilter.mesh;
        vertices = mesh.vertices;
    }

    private void FixedUpdate() {
        ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButton(0) && Physics.Raycast(ray, out hit)) {
            Deform(hit.point);
        }
    }

    public void Deform(Vector3 deformPosition) {
        deformPosition = transform.InverseTransformPoint(deformPosition);

        for (int i = 0; i < vertices.Length; i++) {
            float distance = (vertices[i] - deformPosition).sqrMagnitude;

            if (distance < radius) {
                Vector3 directionFromCenter = (vertices[i] - deformPosition);
                directionFromCenter.z = 0f;
                directionFromCenter = directionFromCenter.normalized;
                vertices[i] += ((Vector3.forward * power) + (directionFromCenter * scaleFactor));
            }
        }

        mesh.vertices = vertices;
        Instantiate(cylinder, new Vector3(hit.point.x, hit.point.y, transform.position.z + 0.5f), Quaternion.Euler(270f, 0f, 0f));
    }
}
