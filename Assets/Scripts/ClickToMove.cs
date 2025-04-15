using UnityEngine;
using UnityEngine.AI; // unity engine's navigation features

public class ClickToMove : MonoBehaviour
{
    // This variable holds a reference to the component that makes the character move
    private NavMeshAgent agent;

    // Start() is called once when the game starts
    void Start()
    {
        // Here, the NavMeshAgent component is attached to the same GameObject
        // This agent will handle all the movement and obstacle avoidance for me
        agent = GetComponent<NavMeshAgent>();
    }

    // Update() is called once per frame
    // This is where I check for user input and update the game state
    void Update()
    {
        // Check if the left mouse button was just clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the camera through where the mouse cursor is
            // *A ray is like an invisible laser beam that shoots out from the camera to detect objects*
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // This variable will store details about what the ray hits (if it hits anything)
            RaycastHit hit;

            // Send out the ray and check if it collides with something in the game scene.
            // Physics.Raycast returns true if it finds an object along that line.
            if (Physics.Raycast(ray, out hit))
            {
                // If something was hit (the baked floor object), tell the NavMeshAgent(attached to player) to move to that point.
                // This is how clicking somewhere in the scene makes my character move towards that spot.
                agent.SetDestination(hit.point);
            }
        }
    }
}
