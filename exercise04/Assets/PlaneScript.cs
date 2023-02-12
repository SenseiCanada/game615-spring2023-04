using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using TMPro;

public class PlaneScript : MonoBehaviour
{
    float forwardSpeed = 5;
    float rotateSpeed = 50;
    public GameObject Paperclip;
    public GameObject ShootPoint;
    int score = 0;
  
    public TMP_Text donutScore;
    public GameObject SpawnPoint;
    public GameObject paperPlane;

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
            GameObject clip = Instantiate(Paperclip, ShootPoint.transform.position, Quaternion.identity);
            Rigidbody rb = clip.GetComponent<Rigidbody>();
            rb.AddForce(ShootPoint.transform.forward * 1000);

            Destroy(clip, 3f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("enemy"))
        {
            gameObject.transform.position = SpawnPoint.transform.position;
            
        }

        if (other.CompareTag("wall"))
        {
            gameObject.transform.position = SpawnPoint.transform.position;


        }

        if (other.CompareTag("score"))
        {
            score++;
            donutScore.text = score.ToString();
        }
    }
}