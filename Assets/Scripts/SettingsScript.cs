using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System.Collections;

public class SettingsScript : MonoBehaviour
{
    public Sprite Green;
    public Sprite Red;
    public AudioMixer mixer;
    public Image buttonImage; // Use UnityEngine.UI.Image for UI images
    bool fs;

    private void Start()
    {
        fs = true;
    }

    public void SetVolume(float volume)
    {
        mixer.SetFloat("volume", volume);
        Debug.Log(volume);
    }

    public void SetFullScreen()
    {
        if (fs)
        {
            buttonImage.sprite = Red;
            fs = false;
            Screen.fullScreen = false;
        }
        else
        {
            buttonImage.sprite = Green;
            fs = true;
            Screen.fullScreen = true;
        }
    }


    private IEnumerator QuitButtonSettings()
    {
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadSceneAsync(0);
    }

    public void GetBack()
    {
        StartCoroutine(QuitButtonSettings());
    }
}
