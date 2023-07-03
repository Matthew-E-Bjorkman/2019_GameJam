using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossFight : MonoBehaviour
{
    public string currentLine;

    private StateThree state;
    private bool noMistakes = true;
    private bool lineUnfinished = true;

    private string[] songLines = { "my name is yung dab", "and im here to say", "spot jenny far at the bar", "im in love with a cop", "and that shit aint right"};

    public BossFight(StateThree _state)
    {
        state = _state;
    }

    public void Run()
    {





        while(noMistakes && lineUnfinished)
        {
            noMistakes = false;
            lineUnfinished = false;
        }

        state.finished = true;
    }
}
