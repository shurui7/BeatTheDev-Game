using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    // Specify the name of the next scene you want to load
    public string nextSceneName;

    public GameObject TransitionController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Get the LevelLoaderScript component from the TransitionController GameObject
            LevelLoaderScript levelLoader = TransitionController.GetComponent<LevelLoaderScript>();
            if (levelLoader != null)
            {
                // Call the LoadNextLevel method
                levelLoader.LoadNextLevel(nextSceneName);
            }
            else
            {
                Debug.LogError("LevelLoaderScript component not found on TransitionController GameObject.");
            }
        }
    }
}
