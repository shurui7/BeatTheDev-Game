using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() { StartCoroutine(PlayRoutine()); }

    public void ExitGame() { Application.Quit(); }

    public void Settings() { StartCoroutine(SettingsRoutine()); }

    private IEnumerator PlayRoutine()
    {
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadSceneAsync(11);
        Time.timeScale = 1.0f;
    }

    private IEnumerator SettingsRoutine()
    {
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadSceneAsync(10);
    }

    private IEnumerator QuitRoutine()
    {
        yield return new WaitForSeconds(0.25f); // Added missing semicolon and f to specify float

        // Check if running in the Unity Editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
