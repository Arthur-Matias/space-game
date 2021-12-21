using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private bool passedTroughtScreen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xRange = 10;
        float yRange = 5;
        if(transform.position.x > -xRange && transform.position.x < xRange)
        {
            if(transform.position.y > -yRange && transform.position.y < yRange)
            {
                passedTroughtScreen = true;
            }
        }

        if(Time.deltaTime > 10f)
        {
            passedTroughtScreen=true;
        }

        if (transform.position.x < -xRange || transform.position.x > xRange)
        {
            if(transform.position.y < -yRange || transform.position.y > yRange)
            {
                if (passedTroughtScreen)
                {
                    Destroy(gameObject);
                }
            }
        }

    }
}
