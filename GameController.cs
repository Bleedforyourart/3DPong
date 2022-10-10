using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{ 
    public Text PlayerScoreText;
    public Text CompScoreText;
    public Text TimerText;
    public int MatchTime = 120;
    private float StartTime = 0;
    private int PlayerScore = 0;
    private int CompScore = 0;
    private bool MatchActive = false;
    public Ball ball;
    public GameObject GameOver;


    void Start()
    {
        GameOver.SetActive(false);
        SetTimeDisplay(MatchTime);
        StartTime = Time.time;
        MatchActive = true;
        FindObjectOfType<GameSounds>().GameMusic();
    }
public void ResetBall()
    {
        if (MatchActive)
        {
            if (ball != null)
            {
                ball.transform.position = new Vector3(0f, 1f, 0f);
            }
        }
    }
    public void IncrementPlayerScore()
    {
        if (MatchActive)
        {
            PlayerScore++;
            PlayerScoreText.text = "Player: " + PlayerScore.ToString();
            Debug.Log("Player Scored!!");
            Debug.Log("Score is: " + PlayerScore.ToString());
        }
    }
    public void IncrementCompScore()
    {
        if (MatchActive)
        {
            CompScore++;
            CompScoreText.text = "Computer: " + CompScore.ToString();
            Debug.Log("Computer Scored!!");
            Debug.Log("Score is: " + CompScore.ToString());
        }
    }
    
    private void SetTimeDisplay(float TimeDisplay)
    {
        TimerText.text = "Time: " + GetTimeDisplay(TimeDisplay);
    }

    void Update()
    {
        if (Time.time - StartTime < MatchTime)
        {
            float ElapsedTime = Time.time - StartTime;
            SetTimeDisplay(MatchTime - ElapsedTime);
        }
        else
        {
            MatchActive = false;
            SetTimeDisplay(0);

            if (PlayerScore > CompScore)
            {
                TimerText.text = "PLAYER WINS! ";
            }
            else if (PlayerScore < CompScore)
            {
                TimerText.text = "COMPUTER WINS!";
            }
            else
            {
                TimerText.text = "Tie Game!";
            }

            ball.transform.position = new Vector3(0f, 1f, 0f);
            PlayerScoreText.color = Color.red;
            CompScoreText.color = Color.red;
            TimerText.color = Color.red;
            GameOver.SetActive(true);
            FindObjectOfType<GameSounds>().EndMusic();
        }
    }   
   

    private string GetTimeDisplay (float TimetoShow)
    {
        int SecondsToShow = Mathf.CeilToInt(TimetoShow);
        int Seconds = SecondsToShow % 60;
        string SecondsDisplay = (Seconds < 10) ? "0" + Seconds.ToString() : Seconds.ToString();
        int Minutes = (SecondsToShow - Seconds) / 60;
        return Minutes.ToString() + ":" + SecondsDisplay;
    }
}
