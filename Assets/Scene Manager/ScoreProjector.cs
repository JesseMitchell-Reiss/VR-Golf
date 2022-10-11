using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreProjector : MonoBehaviour
{
    public TextMeshPro text;
    private void Start()
    {
        text = this.GetComponent<TextMeshPro>();
        int totalScore = 0;
        foreach(int i in ScoreTracker.levelScores)
        {
            totalScore += i;
        }
        text.text = "Score: " + totalScore.ToString();
    }
    public void returnToStart()
    {
        SceneManager.LoadScene(0);
    }
}
