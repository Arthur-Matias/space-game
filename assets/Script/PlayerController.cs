using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject gameOverScene;
    private SpriteRenderer spriteRenderer;

    public float verticalInput;
    public float horizontalInput;

    public string Status = "alive";
    public int score = 0;

    public Text scoreText;

    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * speed);
        transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, -horizontalInput * Time.deltaTime * 270));
        edges();

        if (Input.GetKeyDown(KeyCode.Space) && Status == "alive")
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }
    }
    private void edges() {
        float horizontalEdge = 10f;
        float verticalEdge = 5f;
        if (transform.position.x >= horizontalEdge) {
            transform.position = new Vector3(transform.position.x - (horizontalEdge * 2), transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= -horizontalEdge) {
            transform.position = new Vector3(transform.position.x + (horizontalEdge *  2), transform.position.y, transform.position.z);
        }

        if (transform.position.y >= verticalEdge)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - (verticalEdge * 2), transform.position.z);
        }
        else if (transform.position.y <= -verticalEdge) {
            transform.position = new Vector3(transform.position.x, transform.position.y + (verticalEdge * 2), transform.position.z);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Meteor"))
        {
            spriteRenderer.color = Color.red;
            Instantiate(gameOverScene, transform.position, Quaternion.identity);
        }
    }
}
