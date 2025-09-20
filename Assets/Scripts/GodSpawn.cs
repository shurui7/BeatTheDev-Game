using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GodSpawn : MonoBehaviour
{
    // Height to teleport the player above the spike
    public float teleportHeight = 20f;

    // Tag to identify spike objects
    public string spikeTag = "Spike";

    private Vector2 GoBack;

    // Respawn
    private int TimesOfRespawn = 3;
    private int HowManyRespawns;
    public Vector2 SpawnPos;


    //Respawn UI
    [SerializeField] private GameObject Heart1;
    [SerializeField] private GameObject Heart2;
    [SerializeField] private GameObject Heart3;


    // Reference to the player's Rigidbody2D component
    private Rigidbody2D rb;

    void Start()
    {
        // Get the player's Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
        SpawnPos = rb.position;
        HowManyRespawns = 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (TimesOfRespawn > HowManyRespawns)
        {
            if (collision.gameObject.CompareTag(spikeTag))
            {

                // Store the new velocity in GoBack
                GoBack = new Vector2(rb.position.x - 3f, rb.position.x + teleportHeight);
                rb.position = GoBack;
                HowManyRespawns += 1;
            }
        }
        if (TimesOfRespawn <= HowManyRespawns)
        {
            Debug.Log("U Died");
            rb.position = SpawnPos;
            HowManyRespawns = 0;
            ResetHearts();
        }
        
    }

    private void Update()
    {
        if (HowManyRespawns == 1) // Use '==' instead of '='
        {
            Heart3.SetActive(false); // Use 'SetActive' instead of 'active'
        }
        if (HowManyRespawns == 2) // Use '==' instead of '='
        {
            Heart2.SetActive(false); // Use 'SetActive' instead of 'active'
        }
        if (HowManyRespawns == 3) // Use '==' instead of '='
        {
            Heart1.SetActive(false); // Use 'SetActive' instead of 'active'
        }
    }

    private void ResetHearts()
    {
        Heart3.SetActive(true);
        Heart2.SetActive(true);
        Heart1.SetActive(true);
    }

}
