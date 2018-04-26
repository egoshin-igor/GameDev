using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public enum Player
    {
        Person,
        AI
    }

    public static Player playerOne;
    public static Player playerTwo;
    public static bool isPlayerOne = true;
    public GameObject playerButtons;

    private void Awake()
    {
        CheckFirstPlayerButton();
        CheckPlayerOneButton();
        CheckPlayerTwoButton();
    }

    private void Update()
    {
        GameObject obj = CommonFunctions.GetObjectByClick();
        if (obj != null)
        {
            isPlayerOne = obj.name == "player_two" ? true : obj.name == "player_one" ? false : ClickHandler.isPlayerOne;
            ClickHandler.isPlayerOne = isPlayerOne;
            playerOne = obj.name == "AI_one" ? Player.Person : obj.name == "person_one" ? Player.AI : playerOne;
            playerTwo = obj.name == "AI_two" ? Player.Person : obj.name == "person_two" ? Player.AI : playerTwo;

            CheckPlayerOneButton();
            CheckPlayerTwoButton();
        }
        CheckFirstPlayerButton();
    }


    private void CheckFirstPlayerButton()
    {
        if (isPlayerOne)
        {
            playerButtons.transform.Find("firstPlayer/player_one").gameObject.SetActive(true);
            playerButtons.transform.Find("firstPlayer/player_two").gameObject.SetActive(false);
        }
        else
        {
            playerButtons.transform.Find("firstPlayer/player_two").gameObject.SetActive(true);
            playerButtons.transform.Find("firstPlayer/player_one").gameObject.SetActive(false);
        }
    }

    private void CheckPlayerOneButton()
    {
        if (playerOne == Player.Person)
        {
            playerButtons.transform.Find("playerOne/AI_one").gameObject.SetActive(false);
            playerButtons.transform.Find("playerOne/person_one").gameObject.SetActive(true);
        }
        else
        {
            playerButtons.transform.Find("playerOne/AI_one").gameObject.SetActive(true);
            playerButtons.transform.Find("playerOne/person_one").gameObject.SetActive(false);
        }
    }

    private void CheckPlayerTwoButton()
    {
        if (playerTwo == Player.Person)
        {
            playerButtons.transform.Find("playerTwo/AI_two").gameObject.SetActive(false);
            playerButtons.transform.Find("playerTwo/person_two").gameObject.SetActive(true);
        }
        else
        {
            playerButtons.transform.Find("playerTwo/AI_two").gameObject.SetActive(true);
            playerButtons.transform.Find("playerTwo/person_two").gameObject.SetActive(false);
        }

    }
}
