using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public static event Action<string> ObjectHit;

    public GameObject player;
    public Rigidbody playerRigidbody;
    public Animator animator;

    public float jumpForce;

    bool jump;

    public AudioSource sfxAudioSource;
    public AudioClip jumpSound;
    public AudioClip gameOverClip;

    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isGrounded = false;
                animator.SetTrigger("Jump");
                playerRigidbody.velocity = Vector3.up * jumpForce;
                jump = true;
                sfxAudioSource.PlayOneShot(jumpSound);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstracle")
        {
            if (ObjectHit != null)
                ObjectHit("hit");
            sfxAudioSource.PlayOneShot(gameOverClip);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

}
