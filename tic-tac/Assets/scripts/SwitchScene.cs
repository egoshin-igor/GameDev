using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    private void Update()
    {
        if (WinsHandler.GameOver)
        {
            SceneManager.LoadScene("gameOver");
        }

        GameObject obj = CommonFunctions.GetObjectByClick();

        if (obj != null && obj.name == "start")
        {
            SceneManager.LoadScene("main");
        }

        if (obj != null && obj.name == "exit")
        {
            Application.Quit();
        }

        if (obj != null && obj.name == "restart")
        {
            SceneManager.LoadScene("main");
        }

        if (obj != null && obj.name == "settings")
        {
            SceneManager.LoadScene("settings");
        }

        if (obj != null && obj.name == "main_menu")
        {
            SceneManager.LoadScene("menu");
        }
    }
}