using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstCutSceneScript : MonoBehaviour
{
    public SpriteRenderer Sign;
    public SpriteRenderer SignPurp;
    public Sprite Phrase1;
    public Sprite Phrase2;
    public Sprite Phrase3;
    public Transform purp;
    public Transform bg;
    public Camera cam;
    private float startZoom = 14.42824f; // Adjust as needed
    private float finishZoom = 3f; // Adjust as needed
    private float smoothTime = 0.25f;
    private float velocity = 0f;

    void Start()
    {
        StartCoroutine(CutScene(cam));
    }

    private IEnumerator CutScene(Camera mainCamera)
    {
        mainCamera.GetComponent<Awesome2DCamera>().target = bg;
        SignPurp.enabled = false;
        Sign.sprite = Phrase1;
        yield return new WaitForSeconds(3f);
        Sign.sprite = Phrase2;
        yield return new WaitForSeconds(3f);
        SignPurp.enabled = true;
        mainCamera.GetComponent<Awesome2DCamera>().target = purp;
        yield return new WaitForSeconds(6f);
        SignPurp.enabled = false;
        mainCamera.GetComponent<Awesome2DCamera>().target = bg;
        Sign.sprite = Phrase3;
        yield return new WaitForSeconds(3f);

        // Call the ZoomTransition coroutine from CameraZoom script
        yield return StartCoroutine(ZoomTransition(mainCamera, startZoom, finishZoom, smoothTime));
        yield return new WaitForSeconds(0.25f);

        SceneManager.LoadSceneAsync(12);
    }

    private IEnumerator ZoomTransition(Camera cam, float startSize, float endSize, float time)
    {
        float elapsedTime = 0f;
        float currentZoom = cam.orthographicSize;

        while (elapsedTime < time)
        {
            float newZoom = Mathf.Lerp(currentZoom, endSize, elapsedTime / time);
            cam.orthographicSize = newZoom;

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        cam.orthographicSize = endSize;
    }
}
