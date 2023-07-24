using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("--- TEMEL LEVEL OBJELERÝ")]
    [SerializeField] private GameObject Platform;
    [SerializeField] private GameObject Top;
    [SerializeField] private GameObject Pota;
    [SerializeField] private GameObject PotaBuyume;
    [SerializeField] private GameObject[] OzellikNoktalari;
    [SerializeField] private AudioSource[] Sesler;
    [SerializeField] private ParticleSystem[] Efektler;



    [Header("--- UI OBJELERÝ")]
    [SerializeField] private Image[] GorevGorselleri;
    [SerializeField] private Sprite GorevTamamSprite;
    [SerializeField] private int AtilmasiGerekenTop;
    [SerializeField] private GameObject[] Paneller;
    [SerializeField] private TextMeshProUGUI LevelAd;
    [SerializeField] private TextMeshProUGUI Sure;
    [SerializeField] private GameObject BaslangicBtn;



    int BasketSayisi, oyunBaslamaTimer=3;
    float parmakPozX;
    bool baslangic = false;
    void Start()
    {
        LevelAd.text ="Level : "+ SceneManager.GetActiveScene().name;
        for (int i = 0; i < AtilmasiGerekenTop; i++) 
        {
            GorevGorselleri[i].gameObject.SetActive(true);
        }
        
        //Invoke("ozellikolussun", 3f);
    }

    void ozellikolussun()
    {
        
        int RandomSayi=Mathf.FloorToInt(Random.Range(0,OzellikNoktalari.Length));   
        PotaBuyume.transform.position = OzellikNoktalari[RandomSayi].transform.position;
        PotaBuyume.SetActive(true);
    }
    void Update()
    {
        if (Time.timeScale != 0 && baslangic==true)
        {
            //Dokunma
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                //Vector3 TouchPoz = Camera.main.ScreenToWorldPoint(touch.position);
                Vector3 TouchPoz = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        parmakPozX = TouchPoz.x - Platform.transform.position.x;
                        break;

                    case TouchPhase.Moved:
                        if (TouchPoz.x - parmakPozX > -1.4 && TouchPoz.x - parmakPozX < 1.4)
                        {
                            Platform.transform.position = Vector3.Lerp(Platform.transform.position, new Vector3(TouchPoz.x - parmakPozX,
                                Platform.transform.position.y, Platform.transform.position.z), 5f);
                        }
                        break;
                }
            }
            //Klavye
            //if (Input.GetKey(KeyCode.LeftArrow))
            //{
            //    if (Platform.transform.position.x > -1.4)
            //        Platform.transform.position = Vector3.Lerp(Platform.transform.position, new Vector3(Platform.transform.position.x - 1f,
            //           Platform.transform.position.y, Platform.transform.position.z), .050f);
            //}
            //else if (Input.GetKey(KeyCode.RightArrow))
            //{
            //    if (Platform.transform.position.x < 1.4)
            //        Platform.transform.position = Vector3.Lerp(Platform.transform.position, new Vector3(Platform.transform.position.x + 1f,
            //           Platform.transform.position.y, Platform.transform.position.z), .050f);
            //}
        }
    }

    public void Basket(Vector3 Poz)
    {
        Sesler[1].Play();
        Efektler[0].transform.position = Poz;
        Efektler[0].gameObject.SetActive(true);
        Efektler[0].Play();

        BasketSayisi++;
        GorevGorselleri[BasketSayisi - 1].sprite = GorevTamamSprite;
        if (BasketSayisi == AtilmasiGerekenTop)
        {
            Kazandýn();
        }
        if(BasketSayisi == 1)
        {
            ozellikolussun();
        }
    }
    public void kaybettin()
    {
        Kaybettin();
    }
    void Kazandýn()
    {
        Paneller[1].SetActive(true);
        //PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1); Normali bu
        Sesler[3].Play();
        Time.timeScale = 0;
    }
    void Kaybettin()
    {
        Paneller[2].SetActive(true);
        Sesler[2].Play();
        Time.timeScale = 0;
    }
    public void potaBuyutme( Vector3 Poz)
    {
        Sesler[0].Play();
        Efektler[1].transform.position = Poz;
        Efektler[1].gameObject.SetActive(true);
        Efektler[1].Play();
        Pota.transform.localScale = new Vector3(55f, 55f, 55f);
    }
    public void ButonIslemleri(string Deger)
    {
        switch(Deger)
        {
            case "Baslat": StartCoroutine(oyunuBaslat()); BaslangicBtn.SetActive(false); break;
            case "Durdur":
                Paneller[0].SetActive(true); 
                Time.timeScale = 0; break;
            case "DevamEt": 
                Paneller[0].SetActive(false);
                Time.timeScale = 1;
                break;
            case "Tekrar":
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
            case "Ayarlar":
                //Ayarlar Panel
                Time.timeScale = 1;
                break;
            case "Cikis":
                Application.Quit();
            break;
            case "YeniBolum":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
                break;
        }
    }
    IEnumerator oyunuBaslat()
    {
        Sure.text = oyunBaslamaTimer.ToString();
        while (true)
        {
            yield return new WaitForSeconds(1f);
            
            oyunBaslamaTimer--;
            Sure.text = oyunBaslamaTimer.ToString();
            Debug.Log(oyunBaslamaTimer.ToString());

            if (oyunBaslamaTimer == 0)
            {
                Sure.text = "Hadi Kolay Gelsin";
                Paneller[3].SetActive(false);
                baslangic = true;
                Top.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezePositionZ;
                break;
            }
        }
    }
}

