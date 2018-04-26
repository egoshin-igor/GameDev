using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject zeroWinsButon;
    public GameObject crossWinsButon;
    public GameObject deadHeat;
    //public GameObject restart;
    //public GameObject mainMenu;

    private void Awake()
    {
        if (WinsHandler.GameOver)
        {
            zeroWinsButon.SetActive(false);
            crossWinsButon.SetActive(false);
            deadHeat.SetActive(false);

            if (WinsHandler.ZeroWin)
            {
                zeroWinsButon.SetActive(true);
            }
            else if (WinsHandler.CrossWin)
            {
                crossWinsButon.SetActive(true);
            }
            else
            {
                deadHeat.SetActive(true);
            }
            RestartGame();
        }
    }

    public static void RestartGame()
    {

        WinsHandler.GameOver = false;
        WinsHandler.CrossWin = false;
        WinsHandler.ZeroWin = false;
        WinsHandler.ClearStates();
        ClickHandler.freeCells = 9;
        ClickHandler.isPlayerOne = Settings.isPlayerOne;
        ClickHandler.blocks = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    }
}
