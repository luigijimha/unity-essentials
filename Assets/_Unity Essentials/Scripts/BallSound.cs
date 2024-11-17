using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSound : MonoBehaviour
{
    public AudioClip blockSound;
    public AudioClip rampSound;
    private AudioSource audioSource;

    void Start()
    {
        // Add or find an AudioSource component on this GameObject
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Block"))
        {
            audioSource.PlayOneShot(blockSound);
        }

        if (collision.collider.CompareTag("Ramp"))
        {
            audioSource.PlayOneShot(rampSound);
        }
    }
}
