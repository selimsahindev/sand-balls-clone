using UnityEngine;

public class InputManager : MonoBehaviour
{
    public SurfaceDeformer deformer;

    private Camera cam;

    #region Singleton
    public static InputManager instance = null;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    private void Start() {
        cam = Camera.main;
    }

    private void OnMouseDown() {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit)) {
            deformer.DeformSurface(hit.point);
            Debug.Log(hit.point);
        }
    }

}