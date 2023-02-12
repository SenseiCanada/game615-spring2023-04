using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    float forwardSpeed = 50;
    float rotateSpeed = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, rotateSpeed * Time.deltaTime, 0, Space.Self);
        gameObject.transform.Translate(transform.forward * forwardSpeed * Time.deltaTime, Space.World);
    }
}
