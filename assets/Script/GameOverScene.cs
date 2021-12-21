using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    public GameObject spawnManager;
    private PlayerController playerScript;

    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        playerScript.Status = "dead";
        spawnManager = GameObject.Find("SpawnManager");
        Destroy(spawnManager);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            playerScript.score = 0;
            playerScript.Status = "alive";
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
    }
}
