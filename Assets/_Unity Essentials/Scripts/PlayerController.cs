using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; // Player movement speed
    public float rotationSpeed = 120.0f; // Player rotation speed
    public float jumpForce = 5.0f; // Jump force
    public AudioClip onJumpSound;
    public AudioClip onVictorySound;
    public AudioClip onCollectSound;
    private AudioSource audioSource;

    private Rigidbody rb; // Reference to the Rigidbody component

    public GameObject onVictoryEffect;
    private bool victoryFlag = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Access player's Rigidbody

        // Add or find an AudioSource component on this GameObject
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void Update()
    {
        // Allow jumping if vertical velocity is near zero
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);

            // Play sound effect
            audioSource.PlayOneShot(onJumpSound);
        }
    }

    private void FixedUpdate()
    {
        // Move player based on vertical input
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * moveVertical * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);

        // Rotate player based on horizontal input
        float turn = Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    public void Victory()
    {
        // Instantiate the particle effect
        Instantiate(onVictoryEffect, transform.position, transform.rotation);

        if(victoryFlag) {
            // Play sound effect
            audioSource.PlayOneShot(onVictorySound);

            // Mute game music
            GameObject musicObject = GameObject.FindWithTag("Music");
            if (musicObject != null)
            {
                AudioSource audioSource = musicObject.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    audioSource.mute = true;
                }
            }

            victoryFlag = false;
        }
    }

    public void PlayCollectSound() {
        // Play sound effect
        audioSource.PlayOneShot(onCollectSound);
    }
}
