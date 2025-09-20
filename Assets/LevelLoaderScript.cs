using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderScript : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1.0f;

    public void LoadNextLevel(string LevelName)
    {
        StartCoroutine(LoadLevel(LevelName));
    }

    IEnumerator LoadLevel(string levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);


    }
}
