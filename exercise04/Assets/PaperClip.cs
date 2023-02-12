using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PaperClip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("enemy"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

    }
}
