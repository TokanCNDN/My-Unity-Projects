using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PotaBuyutme : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Sure;
    [SerializeField] private int BaslangicSuresi;
    [SerializeField] private GameManager _GameManager;
    IEnumerator Start()
    {
        Sure.text = BaslangicSuresi.ToString();

        while (true) {
            yield return new WaitForSeconds(1f);

            BaslangicSuresi--;
            Sure.text = BaslangicSuresi.ToString();

            if(BaslangicSuresi== 0 ) {
                gameObject.SetActive(false);
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        _GameManager.potaBuyutme(transform.position);
    }
}
