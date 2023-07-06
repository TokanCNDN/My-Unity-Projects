using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PİpesSpawn : MonoBehaviour
{
    public float MaxTime = 1;//kaç saniyede yeni bir pipe gelicek
    public float timer = 0;//zamanlayıcı tutmak için
    public GameObject pipe;
    public float yukseklik;

    void Start()
    {
        GameObject newpipe = Instantiate(pipe);
        Debug.Log(newpipe.transform.position+ "ilk");
        newpipe.transform.position = transform.position + new Vector3(0, Random.Range(-yukseklik, yukseklik), 0);
        Debug.Log(newpipe.transform.position+"Yeni");
    } 

    void Update()
    {
        if(timer>MaxTime)
        {
            GameObject newpipe = Instantiate(pipe);
            newpipe.transform.position = transform.position + new Vector3(0, Random.Range(-yukseklik, yukseklik), 0);
            Destroy(newpipe,15);
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
