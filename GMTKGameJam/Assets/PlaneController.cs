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

    public Vector3 setDirection;
    public int setValue;

    // Start is called before the first frame update
    void Start()
    {
        setValue = -1;
           setDirection = new Vector3(-1, -1, 0);
       // InvokeRepeating("ChangeDirection", 5f, 5f);

    }

    // Update is called once per frame
    void Update()
    {
        /*        var axisValue = Input.GetAxis("Horizontal");
                if (Input.GetButton("Horizontal"))
                {
                    objRigidbody.angularVelocity = Vector3.zero;
                    var valueHolder = new Vector3(setDirection.x, setDirection.y, 0);
                    objRigidbody.AddForce(valueHolder * Time.deltaTime * sideForce * setValue* axisValue);

                    targetRoartion = Quaternion.AngleAxis(30, Vector3.back * axisValue);
                    transform.rotation = Quaternion.Lerp(transform.rotation, targetRoartion, 10 * smooth * Time.deltaTime);

                }
                else
                {

                    objRigidbody.AddForce(setDirection * Time.deltaTime * sideForce);
                    objRigidbody.AddTorque(Vector3.forward * Time.deltaTime * rotaionSpeed);
                }*/

        var axisValue = Input.GetAxis("Horizontal");
        if (Input.GetButton("Horizontal"))
        {
            objRigidbody.angularVelocity = Vector3.zero;
            var valueHolder = new Vector3(setDirection.x, setDirection.y, 0);
            transform.Translate(valueHolder * Time.deltaTime * sideForce * setValue * axisValue);
          
            targetRoartion = Quaternion.AngleAxis(30, Vector3.back * axisValue);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRoartion, 10 * smooth * Time.deltaTime);

        }
        else
        {

            transform.Translate(setDirection * Time.deltaTime * sideForce);
           // objRigidbody.AddTorque(Vector3.forward * Time.deltaTime * rotaionSpeed);
        }

       
     
    }

    public void ChangeDirection()
    {
        setValue = Random.Range(0, 2) ;
        setValue = setValue == 0 ? -1 : 1;
        setDirection = new Vector3(setValue, -1, 0);
    }


}
