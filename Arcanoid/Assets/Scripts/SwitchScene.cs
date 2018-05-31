using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public void OnMouseUp()
    {
        GameObject obj = gameObject;

        if (obj != null)
        {
            if (obj.name == "new_game")
            {
                SceneManager.LoadScene("Levels");
            }
            else if (obj.name == "level_one")
            {
                Levels.levelName = "level_one.txt";
                SceneManager.LoadScene("Main");
            }
            else if (obj.name == "level_two")
            {
                Levels.levelName = "level_two.txt";
                SceneManager.LoadScene("Main");
            }
            else if (obj.name == "exit")
            {
                Application.Quit();
            }
        }
    }
}