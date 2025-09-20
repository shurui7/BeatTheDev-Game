using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveSystem : MonoBehaviour
{
    // Variable to store the scene build number
    private int sceneBuildNumber;

    // Method to save the scene build number to a JSON file
    public void Save()
    {
        // Get the current scene build index
        int sceneBuildIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;

        // Create a JSON object to store the scene build number
        SceneBuildNumberData data = new SceneBuildNumberData();
        data.sceneBuildNumber = sceneBuildIndex;

        // Convert the data object to JSON format
        string json = JsonUtility.ToJson(data);

        // Determine the file path for saving (in the persistent data path)
        string filePath = Path.Combine(Application.persistentDataPath, "save.json");

        // Write JSON data to a file
        File.WriteAllText(filePath, json);

        Debug.Log("Scene build number saved to: " + filePath);
    }

    // Method to load the scene build number from a JSON file
    public void Load()
    {
        // Determine the file path for loading (in the persistent data path)
        string filePath = Path.Combine(Application.persistentDataPath, "save.json");

        if (File.Exists(filePath))
        {
            // Read the JSON data from the file
            string json = File.ReadAllText(filePath);

            // Deserialize JSON data into SceneBuildNumberData object
            SceneBuildNumberData data = JsonUtility.FromJson<SceneBuildNumberData>(json);

            // Assign scene build number to the variable
            sceneBuildNumber = data.sceneBuildNumber;

            Debug.Log("Scene build number loaded: " + sceneBuildNumber);

            SceneManager.LoadScene(sceneBuildNumber);
            Time.timeScale = 1.0f;

        }
        else
        {
            Debug.LogWarning("Scene build number file not found at path: " + filePath);
        }
    }

    // Data structure to hold scene build number
    [System.Serializable]
    private class SceneBuildNumberData
    {
        public int sceneBuildNumber;
    }
}
