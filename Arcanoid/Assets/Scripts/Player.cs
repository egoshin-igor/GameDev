using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float boundary;
    public float playerVelocity;
    private Vector3 playerPosition;

    void Start()
    {
        playerPosition = gameObject.transform.position;
    }

    void Update()
    {
        playerPosition.x += Input.GetAxis("Horizontal") * playerVelocity;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Levels");
        }

        if (playerPosition.x < -boundary)
        {
            transform.position = new Vector3(-boundary + 0.03f, playerPosition.y, playerPosition.z);
        }
        else if (playerPosition.x > boundary)
        {
            transform.position = new Vector3(boundary - 0.03f, playerPosition.y, playerPosition.z);
        }
        else
        {
            transform.position = playerPosition;
        }
    }
}
