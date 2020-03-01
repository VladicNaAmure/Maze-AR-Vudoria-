using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerControl : MonoBehaviour
{
    public bool isBool = true;
    private Rigidbody rigBody;

    // Start is called before the first frame update
    void Start()
    {
        rigBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //float x = Input.acceleration.x;
        //float z = -Input.acceleration.z;

        Vector3 tilt = Input.acceleration;

        //if (isBool)
            //tilt = Quaternion.Euler(0, 0, 0) * tilt;

        rigBody.AddForce(tilt);
        Debug.DrawRay(transform.position + Vector3.up, tilt, Color.cyan);
    }

    public void IsBool()
    {
        isBool = !isBool;
    }
}
