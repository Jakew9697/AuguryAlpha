using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class ClickToMove : MonoBehaviour
{
    [Header("Navigation")]
    public float stoppingDistance = 0.1f;
    public LayerMask walkableLayer;
    public LayerMask interactableLayer;

    [Header("Visual Feedback")]
    public GameObject destinationMarker;
    public float markerDuration = 1.5f;

    private NavMeshAgent agent;
    private GameObject currentMarker;
    private float markerTimer;
    private bool isMoving = false;
    private Camera mainCamera;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = stoppingDistance;

        // If marker prefab isn't set, create a simple one
        if (destinationMarker == null)
        {
            Debug.LogWarning("Destination marker not assigned. Create a marker prefab for better visual feedback.");
        }
    }

    void Update()
    {
        // Handle both click and click-and-hold movement using new Input System
        if (Mouse.current.leftButton.wasPressedThisFrame || Mouse.current.leftButton.isPressed)
        {
            // Get mouse position from Input System
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Ray ray = mainCamera.ScreenPointToRay(mousePosition);
            RaycastHit hit;

            // Check for interactable objects first (like in OSRS)
            if (Physics.Raycast(ray, out hit, 100f, interactableLayer))
            {
                // Move to the interactable object
                MoveToPosition(hit.point, true);

                // Handle interaction (you'd implement this based on what was clicked)
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    StartCoroutine(InteractWhenReached(interactable));
                }
            }
            // Otherwise just move to the clicked location
            else if (Physics.Raycast(ray, out hit, 100f, walkableLayer))
            {
                MoveToPosition(hit.point, false);
            }
        }

        // Update destination marker
        UpdateDestinationMarker();

        // Check if we've arrived at destination
        if (isMoving && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            isMoving = false;
        }
    }

    private void MoveToPosition(Vector3 position, bool isInteraction)
    {
        // Set the destination
        agent.SetDestination(position);
        isMoving = true;

        // Create destination marker
        CreateDestinationMarker(position);
    }

    private void CreateDestinationMarker(Vector3 position)
    {
        // Clean up previous marker
        if (currentMarker != null)
        {
            Destroy(currentMarker);
        }

        // Create new marker
        if (destinationMarker != null)
        {
            currentMarker = Instantiate(destinationMarker, position, Quaternion.identity);
            markerTimer = markerDuration;
        }
        else
        {
            // Create simple marker if no prefab is assigned
            currentMarker = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            currentMarker.transform.localScale = new Vector3(0.5f, 0.05f, 0.5f);
            currentMarker.transform.position = new Vector3(position.x, position.y + 0.025f, position.z);

            // Remove collider to avoid interference
            Destroy(currentMarker.GetComponent<Collider>());

            // Add basic visual effect
            Renderer renderer = currentMarker.GetComponent<Renderer>();
            renderer.material.color = new Color(1f, 0.8f, 0f, 0.6f);
            markerTimer = markerDuration;
        }
    }

private void UpdateDestinationMarker()
{
    if (currentMarker == null) return;

    if (isMoving)
    {
        // Pulse while travelling (optional)
        float scale = 1f + 0.2f * Mathf.Sin(Time.time * 5f);
        currentMarker.transform.localScale = new Vector3(0.5f * scale, 0.05f, 0.5f * scale);
    }
    else
    {
        // We’ve arrived – destroy the marker instantly
        Destroy(currentMarker);
        currentMarker = null;
    }
}


    private System.Collections.IEnumerator InteractWhenReached(IInteractable interactable)
    {
        // Wait until we reach the destination
        while (isMoving)
        {
            yield return null;
        }

        // Once reached, interact with the object
        interactable.Interact();
    }
}

// Interface for interactable objects (OSRS style)
public interface IInteractable
{
    void Interact();
}
