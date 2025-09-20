using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 Spawnpoint;
    public string spikeTag = "Spike";

    // Start is called before the first frame update
    void Start()
    {
        Spawnpoint = rb.position;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(spikeTag))
        {
            rb.position = Spawnpoint;
        }
    }
}
