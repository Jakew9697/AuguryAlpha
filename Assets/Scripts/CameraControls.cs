using UnityEngine;

public class CameraControls : MonoBehaviour
{
    [Header("Target")]
    public Transform target;

    [Header("Rotation Settings")]
    public float rotationSpeed = 10f;
    public float minPitch = 10f;
    public float maxPitch = 80f;

    [Header("Zoom Settings")]
    public float zoomSpeed = 10f;
    public float minZoom = 0f;
    public float maxZoom = 20f;

    private float currentYaw = 0f;
    private float currentPitch = 45f;
    private float currentZoom = 10f;

    void Start()
    {
        if (target == null) return;

        currentYaw   = transform.eulerAngles.y;
        currentPitch = transform.eulerAngles.x;

        currentZoom  = Vector3.Distance(transform.position, target.position);
        currentZoom  = Mathf.Clamp(currentZoom, minZoom, maxZoom);
    }

    void LateUpdate()
    {
        if (target == null) return;

        if (Input.GetMouseButton(1)) 
        {
            currentYaw   += Input.GetAxis("Mouse X") * rotationSpeed;

            currentPitch -= Input.GetAxis("Mouse Y") * rotationSpeed;
            currentPitch  = Mathf.Clamp(currentPitch, minPitch, maxPitch);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        currentZoom  -= scroll * zoomSpeed;
        currentZoom   = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        Quaternion rotation = Quaternion.Euler(currentPitch, currentYaw, 0);
        Vector3 offset      = new Vector3(0f, 0f, -currentZoom);

        Vector3 desiredPosition = target.position + rotation * offset;

        transform.position = desiredPosition;

        transform.LookAt(target.position);
    }
}
