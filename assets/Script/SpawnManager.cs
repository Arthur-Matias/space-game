using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject meteorPrefab;
    
    public float xRange = 15f;
    public float yRange = 5f;

    private float repeatTime = 0.5f;
    private float repeatRate = 4f;

    private float xRandom;
    private float yRandom;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnMeteor", repeatTime, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        xRandom = Random.Range(0f, 1f);
        yRandom = Random.Range(0f, 1f);

        repeatRate -= (repeatRate * 0.95f) * Time.deltaTime;
    }
    void SpawnMeteor()
    {
        Vector3 position;
        
        if(xRandom > 0.5 && yRandom < 0.5)
        {
            float x = Random.Range(xRange, xRange + 5f);
            float y = -Random.Range(yRange, yRange * 2);
            position = new Vector3(x, y);
        }
        else if(xRandom > 0.5 && yRandom > 0.5)
        {
            float x = Random.Range(xRange, xRange + 5f);
            float y = Random.Range(yRange, yRange * 2);
            
            position = new Vector3(x, y);
        }
        else if(xRandom < 0.5 && yRandom > 0.5)
        {
            float x = -Random.Range(xRange, xRange + 5f);
            float y = Random.Range(yRange, yRange * 2);

            position = new Vector3(x, y);
        }
        else {
            float x = -Random.Range(xRange, xRange + 5f);
            float y = -Random.Range(yRange, yRange * 2);

            position = new Vector3(x, y);
        }
        position += new Vector3(Random.Range(-xRange, xRange + 50f), Random.Range(-xRange, xRange + 50f)); // Arbitrary values
        Instantiate(meteorPrefab, position, meteorPrefab.transform.rotation);

    }
}
