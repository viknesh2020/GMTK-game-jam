using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// Controls the movement of the elements 
/// 
/// </summary>
public class ObjectMover : MonoBehaviour
{

    public float movementBuffer = 1f;
    
    void Update()
    {
        var moveStep = Time.deltaTime * GameManager.Instance.gameSpeed * movementBuffer;
        transform.Translate(Vector3.left * moveStep);
    }


}
