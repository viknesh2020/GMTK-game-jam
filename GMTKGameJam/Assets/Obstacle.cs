using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public ParticleSystem hitEffect;
    public AudioSource hitAudio;
    public Transform objectToRotate;
    public float rotationSpeed;
    public Vector3 rotaionAxis;

    public float damageValue;

    private void Update()
    {
        objectToRotate.Rotate(rotaionAxis* Time.deltaTime * rotationSpeed);
    }

    public void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            Debug.Log("Player Hit");
            hitAudio.Play();
            hitEffect.Play();
            objectToRotate.gameObject.SetActive(false);
            GameManager.healthValue -= damageValue;
            StartCoroutine(DestroyObstacle());
        }
    }

    private void OnEnable()
    {
        objectToRotate.gameObject.SetActive(true);
    }

    IEnumerator DestroyObstacle(){
        yield return new WaitUntil(()=>hitEffect.isStopped );
        this.gameObject.SetActive(false);
    }
}
