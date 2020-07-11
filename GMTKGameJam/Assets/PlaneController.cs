using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public Rigidbody objRigidbody;

    public float rotaionSpeed;
    public float sideForce;

    public Quaternion targetRoartion;
    public float smooth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            // objRigidbody.isKinematic = true;
            objRigidbody.angularVelocity = Vector3.zero;
            objRigidbody.AddForce(new Vector3(-1, -1, 0) * Time.deltaTime * sideForce*-1 * Input.GetAxis("Horizontal"));

            targetRoartion = Quaternion.AngleAxis(30, Vector3.back * Input.GetAxis("Horizontal"));
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRoartion, 10 * smooth * Time.deltaTime);


            Debug.Log("right");
        }
        else
        {
          //  objRigidbody.isKinematic = false;
            Debug.Log("left");
               objRigidbody.AddForce(new Vector3(-1,-1,0) * Time.deltaTime * sideForce);
            objRigidbody.AddTorque(Vector3.forward * Time.deltaTime * rotaionSpeed);
        }

    }
}
