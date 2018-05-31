using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public GameObject platform;

    private bool ballIsActive;
    private Vector3 ballPosition;
    private Vector3 ballInitialForce;

    void Start()
    {
        ballInitialForce = new Vector3(6.5f, 12f, 0);
        NewGame();
    }

    void Update()
    {
        if (!ballIsActive)
        {
            RunBall(buttonName: "Jump");
        }

        if (!ballIsActive && platform != null)
        {
            AttachBall();
        }

        if (ballIsActive && transform.position.y < -6)
        {
            NewGame();
        }
    }

    private void AttachBall()
    {
        ballPosition.x = platform.transform.position.x;
        transform.position = ballPosition;
    }

    private void RunBall(string buttonName)
    {
        if (Input.GetButtonDown(buttonName) == true)
        {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().AddRelativeForce(ballInitialForce, ForceMode.Impulse);
            ballIsActive = true;
        }
    }

    private void NewGame()
    {
        ballIsActive = false;
        ballPosition.x = platform.transform.position.x;
        ballPosition.y = platform.transform.position.y + 1f;
        transform.position = ballPosition;
        GetComponent<Rigidbody>().isKinematic = true;
    }
}
