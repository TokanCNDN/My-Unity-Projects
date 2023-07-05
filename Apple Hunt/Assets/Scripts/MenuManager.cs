using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public GameObject MenuPanel;
    void Start()
    {
        PlayerPrefs.DeleteKey("Scorer");
        Time.timeScale = 0;
    }
    public void baslangıc()
    {
        MenuPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
