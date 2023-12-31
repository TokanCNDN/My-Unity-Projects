using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour
{
    [SerializeField] private GameManager _GameManager;
    [SerializeField] private AudioSource TopSesi;

    private void OnTriggerEnter(Collider other)
    {
        TopSesi.Play();
        if (other.CompareTag("Basket"))
        {
            _GameManager.Basket(transform.position);
        }else if(other.CompareTag("OyunBitti"))
        {
            _GameManager.kaybettin();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        TopSesi.Play();
    }
}
