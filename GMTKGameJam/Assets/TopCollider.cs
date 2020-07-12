using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopCollider : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip planeCrash;

    public PlaneController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlaneController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerController.stopInputControl = true;
            audioSource.PlayOneShot(planeCrash);
        }
    }
}
