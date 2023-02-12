using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BananaCarCounterScript : MonoBehaviour
{
    int carCount = 0;

    public TMP_Text bananaCarCount;

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
        if(other.CompareTag("car"))
        {
            // Add 1 to the variable
            carCount++;

            // Overwrite the text property of the bananaCarCount TMP_Text variable
            // with the value of carCount (we need ToString because it is a
            // number and the text UI property is expecting a string.
            bananaCarCount.text = carCount.ToString();
        }
    }
}
