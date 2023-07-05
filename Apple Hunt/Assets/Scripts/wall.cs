using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        switch(collision.gameObject.tag)
        {
            case "Apple":
                Destroy(GameObject.Find("apple (Clone)"));
                break;
            case "Palamut":
                Destroy(GameObject.Find("Bomb(Clone)"));
                break;

        }
    }
}
