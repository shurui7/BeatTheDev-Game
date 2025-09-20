using UnityEngine;

public class ClickToTp : MonoBehaviour
{
    public Transform player;
    private Vector2 TpPos;
    
    // Update is called once per frame
    void Update()
    {
        // Check for left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            // Get the mouse position in screen coordinates
            Vector3 mousePosition = Input.mousePosition;

            // Convert the screen coordinates to world coordinates
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            // tp player
            player.position = worldPosition;

            // Print the mouse position in world coordinates
            Debug.Log("Mouse Position (World): " + worldPosition);
        }
    }
}
