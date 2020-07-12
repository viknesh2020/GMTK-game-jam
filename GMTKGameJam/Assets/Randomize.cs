using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomize : MonoBehaviour
{
    public PlaneController planeController;
    public bool flag;

    // Start is called before the first frame update
    void Start()
    {
        flag = true;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (flag)
        {
            flag = false;
            StartCoroutine(RandomChange());
            planeController.ChangeDirection();

        }
    }

    IEnumerator RandomChange()
    {
        yield return new WaitForSeconds(4f);
        flag = true;
       
    }


}
