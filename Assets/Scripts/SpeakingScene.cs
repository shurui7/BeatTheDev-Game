using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SpeakingScene : MonoBehaviour
{
    public GameObject Player;
    public Transform PlayerTransform;
    public GameObject mainCamera;
    public Transform SignObject;
    public SpriteRenderer Sign;
    public Sprite Phrase1;
    public Sprite Phrase2;
    public Sprite Phrase3;
    public AudioSource ClickSound;
    public float SizeCam;

    // Start is called before the first frame update
    void Start()
    {
        this.enabled = true;
        Player.GetComponent<PlayerMovement>().enabled = false;
        mainCamera.GetComponent<Awesome2DCamera>().target = SignObject;
        Camera.main.orthographicSize = 7f;
        Sign.sprite = Phrase1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Sign.sprite == Phrase1)
        {
            Sign.sprite = Phrase2;
            ClickSound.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && Sign.sprite == Phrase2)
        {
            Sign.sprite = Phrase3;
            ClickSound.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && Sign.sprite == Phrase3)
        {
            Sign.enabled = false;
            this.enabled = false;
            ClickSound.Play();
            Player.GetComponent<PlayerMovement>().enabled = true;
            mainCamera.GetComponent<Awesome2DCamera>().target = PlayerTransform;
            Camera.main.orthographicSize = SizeCam;
        }
    }
}
