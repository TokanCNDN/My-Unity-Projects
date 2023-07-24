using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Guc : MonoBehaviour
{
    [SerializeField] private float aci;
    [SerializeField] private float UygulanacakGuc;

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(aci, 90, 0)*UygulanacakGuc,ForceMode.Force);


    }
}
