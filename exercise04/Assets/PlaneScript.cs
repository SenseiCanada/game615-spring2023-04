using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class PlaneScript : MonoBehaviour
{
    public float forwardSpeed;
    public float rotateSpeed;
    public GameObject Paperclip;
    public GameObject ShootPoint;
    int score = 0;
    float originSpeed;
    public TMP_Text donutScore;
    public GameObject SpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        originSpeed = forwardSpeed;
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
            rb.AddForce((ShootPoint.transform.forward * 2000 * (score + 1.1f))/2f);

            Destroy(clip, 2f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("enemy"))
        {
            gameObject.transform.position = SpawnPoint.transform.position;
            gameObject.transform.rotation = SpawnPoint.transform.rotation;
            forwardSpeed = originSpeed;
            score = 0;
            donutScore.text = score.ToString();
        }

        if (other.CompareTag("wall"))
        {
            gameObject.transform.position = SpawnPoint.transform.position;
            gameObject.transform.rotation = SpawnPoint.transform.rotation;
            forwardSpeed = originSpeed;
            score = 0;
            donutScore.text = score.ToString();

        }

        if (other.CompareTag("score"))
        {
            score++;
            donutScore.text = score.ToString();
            forwardSpeed = forwardSpeed + score;

        }
    }
}