using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    public AudioSource Coin,Death,Wing;
    public Text ScorerBoard,NewScoreText,MaxScoreText;
    public GameObject Begin_Panel,Finish_Panel;
    public int Score;
    public float ziplama;
    int MaxScore=0, NewScore=0;
    Rigidbody2D rg;
    void Start()
    {
        MaxScore = PlayerPrefs.GetInt("HighScore");
        ScorerBoard.enabled = false;
        Finish_Panel.SetActive(false);
        Time.timeScale = 0;
        rg = GetComponent<Rigidbody2D>();
        Score = 0;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))//Klavye ile kontrol
        {
            rg.velocity = Vector2.up * ziplama;
            Wing.Play();
        }

        //if (Input.touchCount>=1)//Telefon kontrol
        //{
        //    rg.velocity = Vector2.up * ziplama;
        //    Wing.Play();
        //}
        //if(Input.GetMouseButtonDown(0))//Mouse kontrol
        //{
        //    rg.velocity = Vector2.up * ziplama;
        //    Wing.Play();
        //}
        ScorerBoard.text = Score.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Point")
        {
            Score++;
            Coin.Play();      
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Wall")
        {
            Death.Play();
            NewScore = Score;
            if(MaxScore>=NewScore)
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
            Time.timeScale = 0;
            Finish_Panel.SetActive(true);
            ScorerBoard.enabled = false;
        }
    }
   public void Begin()
    {
        Time.timeScale = 1;
        Begin_Panel.SetActive(false);
        ScorerBoard.enabled = true;
    }
    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
}
