using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField]
    Transform ArrowTip;
    [SerializeField]
    GameObject Arrow;

    public Score sc;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(1))//(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newArrow = Instantiate(Arrow, ArrowTip.position, ArrowTip.rotation);
            newArrow.GetComponent<Rigidbody2D>().velocity = ArrowTip.right * 20f;
            Destroy(newArrow, 3);
        }
    }
}
