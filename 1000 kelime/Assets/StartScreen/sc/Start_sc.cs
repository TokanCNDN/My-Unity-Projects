using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Start_sc : MonoBehaviour
{
    public static Start_sc Instance;
    [SerializeField]
    GameObject[] btn;
    public bool sound_check=true;
    public bool vibratation_check =true;
    public string GameMode="standard";
    private void Awake()
    {

        if(Instance==null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    private void Update()
    {
        if(btn[1]==null & btn[0]== null & btn[2] == null & btn[3] == null)
        {
            btn[0] = GameObject.FindGameObjectWithTag("on_btn");
            btn[1] = GameObject.FindGameObjectWithTag("off_btn");
            btn[2] = GameObject.FindGameObjectWithTag("vib_on_btn");
            btn[3] = GameObject.FindGameObjectWithTag("vib_off_btn");
        }
        if (sound_check == true)
        {
            btn[1].SetActive(false);
            btn[0].SetActive(true);
        }
        else
        {
            btn[0].SetActive(false);
            btn[1].SetActive(true);
        }

        if (vibratation_check == true)
        {
            btn[3].SetActive(false);
            btn[2].SetActive(true);
        }
        else
        {
            btn[2].SetActive(false);
            btn[3].SetActive(true);
        }
    }
    public void start_btn()
    {
        SceneManager.LoadScene(1);
    }
    public void sound_op_btn()
    {
        sound_check = false;
    }
    public void sound_of_btn()
    {
        sound_check = true;
    }
    public void vibratation_op_btn()
    {
        vibratation_check = false;
    }
    public void vibratation_of_btn()
    {
        vibratation_check = true;
    }
    public void timer_mode()
    {
        GameMode = "timer";
        SceneManager.LoadScene(1);
    }   
}
