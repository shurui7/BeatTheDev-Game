using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScript : MonoBehaviour
{
     public string nextSceneName;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NextScene());
    }

    private IEnumerator NextScene()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(nextSceneName);
    }
    
}
