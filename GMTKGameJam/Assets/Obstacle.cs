using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public ParticleSystem hitEffect;
    public AudioSource hitAudio;
    public void OnCollisionEnter(Collision col){
        if(col.gameObject.tag == "Player"){
            hitAudio.Play();
            hitEffect.Play();
            StartCoroutine(DestroyObstacle());
        }
    }

    IEnumerator DestroyObstacle(){
        yield return new WaitUntil(()=>hitEffect.isStopped && !hitAudio.isPlaying);
        Destroy(this.gameObject);
    }
}
