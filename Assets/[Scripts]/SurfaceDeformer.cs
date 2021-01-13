using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceDeformer : MonoBehaviour
{
    public float deformationRadius;
    public float deformationPower;

    private MeshFilter meshFilter;
    private Mesh mesh;
    private MeshCollider col;
    private Vector3[] vertices;
    private Camera cam;

    private void Awake() {
        meshFilter = GetComponent<MeshFilter>();
        mesh = meshFilter.mesh;
        col = GetComponent<MeshCollider>();
        vertices = mesh.vertices;
        cam = Camera.main;
    }

    private void OnMouseDown() {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit)) {
            DeformSurface(hit.point);
            Debug.Log(hit.point);
        }
    }

    public void DeformSurface(Vector3 deformPosition) {
        bool deformed = false;

        deformPosition = transform.InverseTransformPoint(deformPosition);

        for (int i = 0; i < vertices.Length; i++) {
            float distance = (vertices[i] - deformPosition).sqrMagnitude;

            if (distance < deformationRadius) {
                // It is correspondint to Z dimension in Unity. But we select Vector3.right according to the local axis of the model.
                vertices[i] += Vector3.right * deformationPower;
                deformed = true;
            }
        }

        if (deformed) {
            mesh.vertices = vertices;
            col.sharedMesh = mesh;
            Debug.Log("Deformed");
        }
    }

}
