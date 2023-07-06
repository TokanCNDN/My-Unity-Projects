using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCont : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("collect"))
        {

            other.gameObject.transform.position = transform.position + Vector3.forward;
            Destroy(gameObject.GetComponent<CollectCont>());
            other.gameObject.AddComponent<CollectCont>();
            other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            other.gameObject.AddComponent<NodeMovement>();
            other.gameObject.GetComponent<NodeMovement>().ConnectNode = transform;
            other.gameObject.tag = "collected";
        }
    }
}
