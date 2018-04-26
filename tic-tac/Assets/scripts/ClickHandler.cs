using System;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{

    public static bool isPlayerOne = true;
    public static int freeCells = 9;

    float timer;

    int blockNumber;
    GameObject block;
    public static List<int> blocks = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    Settings.Player _currentPlayer = isPlayerOne ? Settings.playerOne : Settings.playerTwo;
    bool endOfMove = false;

    private void Update()
    {
        if (_currentPlayer == Settings.Player.AI)
        {
            if (timer < 0.6)
            {
                timer += Time.deltaTime;
            }
            if (timer > 0.6)
            {
                AiMove();
                timer = 0;
            }
        }
        else
        {
            block = CommonFunctions.GetObjectByClick();
            if (block != null)
            {
                var blockName = block.name;
                blockNumber = blockName[blockName.Length - 1] - '0';
                endOfMove = true;
            }

        }
        var isFreeCell = block != null && block.GetComponent<Renderer>().material.color == Color.white;
        if (endOfMove && !WinsHandler.GameOver && isFreeCell)
        {
            blocks.Remove(blockNumber);
            block.GetComponent<Renderer>().material.color = Color.clear;
            if (isPlayerOne)
            {
                block.transform.Find("zero").gameObject.SetActive(false);
                WinsHandler.NumberOfCross[blockNumber] = true;
            }
            else
            {
                block.transform.Find("cross").gameObject.SetActive(false);
                WinsHandler.NumberOfZeros[blockNumber] = true;
            }
            isPlayerOne = !isPlayerOne;
            _currentPlayer = isPlayerOne ? Settings.playerOne : Settings.playerTwo;
            --freeCells;
            endOfMove = false;
        }
    }

    private void AiMove()
    {
        System.Random rand = new System.Random();
        blockNumber = blocks[rand.Next(0, blocks.Count)];
        block = GameObject.Find("block_" + blockNumber.ToString());
        endOfMove = true;
    }
}
