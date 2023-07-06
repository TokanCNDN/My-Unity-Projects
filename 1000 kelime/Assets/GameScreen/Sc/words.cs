using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class words : MonoBehaviour
{
    
    public string[] english = new string[10 * 100];
    public string[] turkish = new string[10 * 100];
    public Text[] check_txt;
    public Text score_txt,time_txt;
    public AudioSource correct_au,wrong_au;
    public set_sc settings = new set_sc();
    int score = 0;
    public int correct , btn_vote , language_vote ,wrong;
    float timer = 60f;
    
    private void Start()
    {
        vote();
        
    }
    private void Update()
    {
        if (settings.gamemod == "timer")
        {
            if (timer >= 0f)
            {
                timer_mode();
            }
            else
            {
                Time.timeScale = 0;
            }
        }
        
        
        score_txt.text = score.ToString();
        if(settings.snd_check==false)
        {
            correct_au.mute = true;
            wrong_au.mute = true;
        }
        else
        {
            correct_au.mute = false;
            wrong_au.mute = false;
        }
    }
    public void right_btn()
    {
        // lng_vote  %2 == 0,  answer turkish
        //if btn_vote %2 == 0, right btn correct
        if(language_vote%2==0)
        {
            if(btn_vote %2==0)
            {
                Debug.Log("doğru");
                correct_au.Play();
                score++;
                vote();
               
            }
            else
            {
               if(settings.vib_check==true)
               {
                    Handheld.Vibrate();
               }
               Debug.Log("yanlış");
               wrong_au.Play();
               vote();
            }
        }
        else
        {
            if (btn_vote % 2 == 0)
            {
                Debug.Log("doğru");
                correct_au.Play();
                score++;
                vote();
                
            }
            else
            {
                if (settings.vib_check == true)
                {
                    Handheld.Vibrate();
                }
                Debug.Log("yanlış");
                wrong_au.Play();
                vote();
            }
        }
        
    }
    public void left_btn()
    {
        // if btn_vote % 2 !=0, left btn correct
        if (language_vote % 2 == 0)//cevap türkçe soru ingilizce
        {
            if (btn_vote % 2 == 0)//buton çift ise sağ doğru --- sol yanlış
            {
                if (settings.vib_check == true)
                {
                    Handheld.Vibrate();
                }
                Debug.Log("yanlış");
                wrong_au.Play();
                vote();
            }
            else//buton tek ise sol doğru --- sağ yanlış
            {
                Debug.Log("doğru");
                correct_au.Play();
                score++;
                vote();
              
            }
        }
        else//cevap ingilizce soru türkçe
        {
            if (btn_vote % 2 == 0)//buton çift ise sağ doğru --- sol yanlış
            {
                if (settings.vib_check == true)
                {
                    Handheld.Vibrate();
                }
                Debug.Log("yanlış");
                wrong_au.Play();
                vote();
            }
            else//buton çift ise sol doğru --- sağ yanlış
            {
                Debug.Log("doğru");
                correct_au.Play();
                score++;
                vote();
            }
        }
    }
    public void vote()
    {
        correct = Random.Range(0, 1001);
        btn_vote = Random.Range(0, 11);
        language_vote = Random.Range(0, 11);
        wrong = Random.Range(0, 1001);
        while (correct == wrong)
        {
            wrong = Random.Range(0, 1001);
        }
        if (language_vote % 2 == 0)
        {
            check_txt[2].text = english[correct];//cevap türkçe soru ingilizce
            if (btn_vote % 2 == 0)//buton çift ise sağ doğru --- sol yanlış
            {
                check_txt[0].text = turkish[correct];//right btn
                check_txt[1].text = turkish[wrong];//left btn
            }
            else//buton tek ise sol doğru --- sağ yanlış
            {
                check_txt[1].text = turkish[correct];//left btn
                check_txt[0].text = turkish[wrong];//right btn
            }
        }
        else
        {
            check_txt[2].text = turkish[correct];//cevap ingilizce soru türkçe
            if (btn_vote % 2 == 0)//buton çift ise sağ doğru --- sol yanlış
            {
                check_txt[0].text = english[correct];//right btn

                check_txt[1].text = english[wrong];//left btn
            }
            else//buton çift ise sol doğru --- sağ yanlış
            {
                check_txt[1].text = english[correct];//left btn
                check_txt[0].text = english[wrong];//right btn

            }
        } 
    }
    public void timer_mode()
    {
        timer = timer - 1 * Time.deltaTime;
        time_txt.text=Mathf.Round(timer).ToString();
    }
}
