using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    float forwardSpeed = 5;
    float rotateSpeed = 50;
    public GameObject Paperclip;
    public GameObject ShootPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        gameObject.transform.Rotate(0, rotateSpeed * Time.deltaTime * hAxis, 0);

        //gameObject.transform.Rotate(0, rotateSpeed * Time.deltaTime, 0, Space.Self);
        gameObject.transform.Translate(transform.forward * forwardSpeed * Time.deltaTime, Space.World);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // This will instantiate and launch 100 prefabs of the banana car.

            GameObject clip = Instantiate(Paperclip, ShootPoint.transform.position, Quaternion.identity);
            //float rotXAmount = Random.Range(-89, -10);
            //float rotYAmount = Random.Range(0, 360);
            //car.transform.Rotate(rotXAmount, rotYAmount, 0);
            Rigidbody rb = clip.GetComponent<Rigidbody>();
            rb.AddForce(ShootPoint.transform.forward * 1000);

            Destroy(clip, 3f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("enemy"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("wall"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("score"))
        {
            //Destroy(other.gameObject);
        }
    }
}