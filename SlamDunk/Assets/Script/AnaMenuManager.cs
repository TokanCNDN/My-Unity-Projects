using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnaMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ////PlayerPrefs.DeleteAll();
        //if (PlayerPrefs.HasKey("Level"))
        //{
        //    SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
        //}
        //else
        //{
        //    PlayerPrefs.SetInt("Level", 1);
        //    SceneManager.LoadScene(1);
        //}
       
    }
    public void btnIslem(string deger)
    {
        switch (deger)
        {
            case "1": SceneManager.LoadScene("1"); break;
            case "2": SceneManager.LoadScene("2"); break;
        }
    }
}
