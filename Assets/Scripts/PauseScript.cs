using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public Canvas pauseCanvas;
    public Canvas pauseCanvasBG;
    private bool PauseIsEnabled;
    private SoundManagerScript soundManager;

    private void Start()
    {
        pauseCanvas.enabled = false;
        pauseCanvasBG.enabled = false;
        PauseIsEnabled = false;
        soundManager = FindObjectOfType<SoundManagerScript>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseIsEnabled)
            {
                HidePauseMenu();
            }
            else
            {
                ShowPauseMenu();
            }
        }
    }


    public void ShowPauseMenu()
    {
        soundManager.PlaySound("button");
        PauseIsEnabled = true;
        Time.timeScale = 0.0f;
        pauseCanvas.enabled = true;
        pauseCanvasBG.enabled = true;
    }

    public void HidePauseMenu()
    {
        soundManager.PlaySound("button");
        PauseIsEnabled = false;
        pauseCanvas.enabled = false;
        pauseCanvasBG.enabled = false;
        Time.timeScale = 1.0f;

    }

    public void ExitGame() { SceneManager.LoadSceneAsync(0); soundManager.PlaySound("button"); }
    public void Settings() { SceneManager.LoadSceneAsync(10); soundManager.PlaySound("button"); }
}
