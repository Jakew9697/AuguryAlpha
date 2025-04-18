// filepath: c:\Users\syncg\GameProjects\AuguryAlpha\Assets\Scripts\CameraControls.cs
using UnityEngine;
using UnityEngine.InputSystem;

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
    public float minZoom = 5f;
    public float maxZoom = 30f;

    [Header("Camera Panning")]
    public float panSpeed = 15f;

    private float currentYaw = 0f;
    private float currentPitch = 45f;
    private float currentZoom = 10f;
    private Vector3 cameraOffset;

    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    void Start()
    {
        if (target == null) return;

        currentYaw = transform.eulerAngles.y;
        currentPitch = transform.eulerAngles.x;

        currentZoom = Vector3.Distance(transform.position, target.position);
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        // Store initial offset from target
        cameraOffset = transform.position - target.position;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // --- Mouse Rotation (Only with Middle Mouse, OSRS style) ---
        if (Mouse.current.middleButton.isPressed)
        {
            // Get mouse delta from the new Input System
            Vector2 mouseDelta = Mouse.current.delta.ReadValue();
            currentYaw += mouseDelta.x * rotationSpeed * Time.deltaTime; // Adjusted sensitivity
            currentPitch -= mouseDelta.y * rotationSpeed * Time.deltaTime; // Adjusted sensitivity
            currentPitch = Mathf.Clamp(currentPitch, minPitch, maxPitch);
        }

        // --- Handle Horizontal Panning with A/D and Left/Right Arrow Keys ---
        Vector3 panMovement = Vector3.zero;

        // Left/Right panning
        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)
        {
            currentYaw -= panSpeed * Time.deltaTime;
        }
        if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
        {
            currentYaw += panSpeed * Time.deltaTime;
        }

        // --- Vertical Rotation with W/S and Up/Down Arrow Keys ---
        if (Keyboard.current.upArrowKey.isPressed || Keyboard.current.wKey.isPressed)
        {
            currentPitch += panSpeed * Time.deltaTime;
        }
        if (Keyboard.current.downArrowKey.isPressed || Keyboard.current.sKey.isPressed)
        {
            currentPitch -= panSpeed * Time.deltaTime;
        }

        // Clamp pitch
        currentPitch = Mathf.Clamp(currentPitch, minPitch, maxPitch);

        // --- Zoom via Scroll Wheel ---
        float scroll = Mouse.current.scroll.y.ReadValue() * 0.01f; // Adjusted for sensitivity
        currentZoom -= scroll * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        // --- Apply Camera Transform ---
        Quaternion rotation = Quaternion.Euler(currentPitch, currentYaw, 0);
        Vector3 offset = new Vector3(0f, 0f, -currentZoom);

        // Always keep the camera focused on the player (OSRS style)
        Vector3 desiredPosition = target.position + rotation * offset;
        transform.position = desiredPosition;

        // Always look at target (OSRS style)
        transform.LookAt(target.position);
    }
}
