using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Levels : MonoBehaviour
{

    const float MAX_WIDTH = 28f;
    const float MIN_HEIGHT = 0.5f;

    static public string levelName = "level_one.txt";
    public GameObject blueBlock;
    public GameObject greenBlock;
    public GameObject redBlock;

    void Start()
    {
        LoadLevel("Assets/Levels/" + levelName);
    }

    void Update()
    {

    }

    private void LoadLevel(string levelFileName)
    {
        StreamReader inFile = new StreamReader(levelFileName);
        float y = 3f;
        string line = "";
        while ((line = inFile.ReadLine()) != null)
        {
            float x = -11f;
            foreach (var ch in line)
            {
                x += 2f;
                if (x < MAX_WIDTH)
                {
                    if (ch == 'b')
                    {
                        Instantiate(blueBlock, new Vector3(x, y, 0), Quaternion.identity, gameObject.GetComponent<Transform>());
                    }
                    else if (ch == 'g')
                    {
                        Instantiate(greenBlock, new Vector3(x, y, 0), Quaternion.identity, gameObject.GetComponent<Transform>());
                    }
                    else if (ch == 'r')
                    {
                        Instantiate(redBlock, new Vector3(x, y, 0), Quaternion.identity, gameObject.GetComponent<Transform>());
                    }
                }
                else
                {
                    break;
                }
            }
            y -= 0.7f;
            if (y < MIN_HEIGHT)
            {
                break;
            }
        }
    }
}
