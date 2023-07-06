using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawn : MonoBehaviour
{
    public float MaxTime = 5, Timer = 0,genislik;
    public GameObject Apple;


    private void Update()
    {
        if(Timer>MaxTime)
        {
            GameObject newApple = Instantiate(Apple);
            newApple.transform.position = transform.position + new Vector3(Random.Range(-genislik, genislik), 0, 0);
            
            Timer = 0;
        }
        Timer += Time.deltaTime;
    }

}
