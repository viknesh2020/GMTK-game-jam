using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public Rigidbody objRigidbody;

    public float rotaionSpeed;
    public float sideForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        objRigidbody.AddForce(Vector3.left * Time.deltaTime * sideForce);
        objRigidbody.AddRelativeTorque(Vector3.forward*Time.deltaTime*rotaionSpeed);
    }
}
