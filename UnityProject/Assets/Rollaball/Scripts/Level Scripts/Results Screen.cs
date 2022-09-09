using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultsScreen : MonoBehaviour
{
    public TMP_Text scoreDisplay;
    public TMP_Text timeDisplay;

    public void ShowResults(int currentScore, float timeRemaining)
    {
        scoreDisplay.text = currentScore.ToString("0000");
        timeDisplay.text = timeRemaining.ToString("0000");
    }
}
