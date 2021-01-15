using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeformPlane : MonoBehaviour
{
    [SerializeField] float radius = 0.8f;
    [SerializeField] float power = 0.7f;

    [Tooltip("For expanding the inner circle")]
    [SerializeField] float scaleFactor = 0.2f;

    [SerializeField] Transform cylinder;
    [SerializeField] List<Transform> holePoints;

    private Camera cam;
    private Ray ray;
    private RaycastHit hit;

    private MeshFilter meshFilter;
    private Mesh mesh;
    private Vector3[] vertices;

    private void Start() {
        cam = Camera.main;
        meshFilter = GetComponent<MeshFilter>();
        mesh = meshFilter.mesh;
        vertices = mesh.vertices;

        CreateHoles();
    }

    private void FixedUpdate() {
        ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButton(0) && Physics.Raycast(ray, out hit)) {
            Deform(hit.point);
        }
    }

    public void Deform(Vector3 deformPosition) {
        Deform(deformPosition, radius);
    }

    public void Deform(Vector3 deformPosition, float radius) {
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
        Instantiate(cylinder, new Vector3(deformPosition.x, deformPosition.y + 10f, transform.position.z + 0.5f), Quaternion.Euler(270f, 0f, 0f));
    }

    private void CreateHoles() {
        foreach(Transform point in holePoints) {
            Deform(point.position);
        }
    }
}
