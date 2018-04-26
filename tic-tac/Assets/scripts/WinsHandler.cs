using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinsHandler : MonoBehaviour
{
    const int NUMBER_OF_ELEMENTS = 9 + 1;

    static private bool[] _numberOfCross = new bool[NUMBER_OF_ELEMENTS];
    static private bool[] _numberOfZeros = new bool[NUMBER_OF_ELEMENTS];

    static public bool GameOver { get; set; }
    static public bool CrossWin { get; set; }
    static public bool ZeroWin { get; set; }

    static public bool[] NumberOfCross
    {
        get
        {
            return _numberOfCross;
        }

        set
        {
            _numberOfCross = value;
        }
    }
    static public bool[] NumberOfZeros
    {
        get
        {
            return _numberOfZeros;
        }

        set
        {
            _numberOfZeros = value;
        }
    }

    private bool IsWin(bool[] numbers)
    {
        return numbers[1] && numbers[2] && numbers[3] ||
            numbers[4] && numbers[5] && numbers[6] ||
            numbers[7] && numbers[8] && numbers[9] ||
            numbers[1] && numbers[4] && numbers[7] ||
            numbers[2] && numbers[5] && numbers[8] ||
            numbers[3] && numbers[6] && numbers[9] ||
            numbers[1] && numbers[5] && numbers[9] ||
            numbers[3] && numbers[5] && numbers[7];
    }

    private void Update()
    {
        if (IsWin(NumberOfCross) && !GameOver)
        {
            GameOver = true;
            CrossWin = true;
        }
        if (IsWin(NumberOfZeros) && !GameOver)
        {
            GameOver = true;
            ZeroWin = true;
        }
        if (ClickHandler.freeCells == 0 && !GameOver)
        {
            GameOver = true;
        }
    }

    private static void ClearArray(ref bool[] array, int size)
    {
        for (int i = 0; i < size; ++i)
        {
            array[i] = false;
        }
    }

    public static void ClearStates()
    {
        ClearArray(ref _numberOfZeros, NUMBER_OF_ELEMENTS);
        ClearArray(ref _numberOfCross, NUMBER_OF_ELEMENTS);
    }
}
