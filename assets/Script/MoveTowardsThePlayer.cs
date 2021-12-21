using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsThePlayer : MonoBehaviour
{
    private GameObject Player;
    private Vector3 direction;

    public float speed = 0.1f;
    public float angle = 0;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        direction = -Vector3.MoveTowards(transform.position, Player.transform.position, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        speed +=  (speed * 0.01f) * Time.deltaTime;
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
