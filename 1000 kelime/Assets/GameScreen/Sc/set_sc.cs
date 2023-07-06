using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class set_sc : MonoBehaviour
{
    [SerializeField]
    GameObject[] btn;
    public bool snd_check = true;
    public bool vib_check = true;
    public string gamemod;

    private void Start()
    {
        snd_check = Start_sc.Instance.sound_check;
        vib_check = Start_sc.Instance.vibratation_check;
        gamemod = Start_sc.Instance.GameMode;
    }
    private void Update()
    {
        if (snd_check == true)
        {
            btn[1].SetActive(false);
            btn[0].SetActive(true);
        }
        else
        {
            btn[0].SetActive(false);
            btn[1].SetActive(true);
        }
        if (vib_check == true)
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
    public void sound_op_btn()
    {
        snd_check  = false;
    }
    public void sound_of_btn()
    {
        snd_check = true;
    }
    public void vibratation_op_btn()
    {
        vib_check = false;
    }
    public void vibratation_of_btn()
    {
        vib_check = true;
    }
}
