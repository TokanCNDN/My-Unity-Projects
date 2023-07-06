using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    int score ;
    public Healt healt;

    private void Start()
    {
        ScoreText = GameObject.FindGameObjectWithTag("Score").gameObject.GetComponent<Text>();
        healt = GameObject.FindGameObjectWithTag("Health").gameObject.GetComponent<Healt>();
        score = PlayerPrefs.GetInt("Scorer");      
    }
    private void OnCollisionEnter2D(Collision2D other)
    {     
            switch (other.gameObject.tag)
            {
            case "Apple":
                score++;
                PlayerPrefs.SetInt("Scorer", score);
                ScoreText.text = score.ToString();
                Debug.Log(score);
                Debug.Log("değdi");
                Destroy(GameObject.Find("arrow(Clone)"));
                Destroy(GameObject.Find("apple (Clone)"));
                break;
            case "Palamut":
                Debug.Log("palamut değdi");
                healt.can--;
                healt.can_sistemi();
                Destroy(GameObject.Find("arrow(Clone)"));
                Destroy(GameObject.Find("Bomb(Clone)"));
                    if (healt.can == 0)
                    {
                    Time.timeScale = 0;
                    healt.scorePanel();
                    }
                break;
        }         
    }
}
