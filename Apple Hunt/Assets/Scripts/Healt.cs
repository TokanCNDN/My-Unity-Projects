using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healt : MonoBehaviour
{
    public GameObject[] health;
    public GameObject ScorePanel;
    public Text NewScoreText, MaxScoreText;
    int MaxScore = 0, NewScore = 0;
    int hasar;
    public int can, maxcan;
    private void Start()
    {
        MaxScore = PlayerPrefs.GetInt("HighScore");
        ScorePanel.SetActive(false);
        can_sistemi();
    }
    public void can_sistemi()
    {
        for (int i = 0; i < maxcan; i++)
        {
            health[i].SetActive(false);
        }
        for (int i = 0; i < can; i++)
        {
            health[i].SetActive(true);
        }
    }
    public void scorePanel()
    {
        ScorePanel.SetActive(true);
        NewScore = PlayerPrefs.GetInt("Scorer");
        if (MaxScore >= NewScore)
        {
            PlayerPrefs.GetInt("HighScore");
            NewScoreText.text = NewScore.ToString();
            MaxScoreText.text = MaxScore.ToString();
        }
        else
        {
            MaxScore = NewScore;
            PlayerPrefs.SetInt("HighScore", MaxScore);
            NewScoreText.text = NewScore.ToString();
            MaxScoreText.text = MaxScore.ToString();
        }
    }
}