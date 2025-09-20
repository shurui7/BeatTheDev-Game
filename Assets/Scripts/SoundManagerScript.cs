using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public AudioClip WalkSound;
    public AudioClip ButtonPress;
    public AudioClip JumpSound;
    public AudioSource audioSrc;
    public AudioSource walkSoundSource; // Reference to the new AudioSource for the walk sound

    private int walkSoundCounter = 0; // Counter for the walk sound activations

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        // Find the GameObject with the WalkSoundSource tag and get its AudioSource component
        walkSoundSource = GameObject.FindGameObjectWithTag("WalkSoundSource").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySound(string clip)
    {
        if (clip == "jump") { audioSrc.PlayOneShot(JumpSound); }
        if (clip == "button") { audioSrc.PlayOneShot(ButtonPress); }
        if (clip == "walk")
        {
            if (walkSoundCounter == 0)
            {
                walkSoundSource.PlayOneShot(WalkSound); // Play the walk sound from the walkSoundSource
            }
            walkSoundCounter++; // Increment the walk sound counter
        }
    }

    public void StopWalkSound()
    {
        walkSoundCounter--; // Decrement the walk sound counter
        if (walkSoundCounter <= 0)
        {
            walkSoundSource.Stop();
            walkSoundCounter = 0; // Ensure counter doesn't go negative
        }
    }
}
