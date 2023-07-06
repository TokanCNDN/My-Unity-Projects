using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMovement : MonoBehaviour
{
    public Transform ConnectNode;
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x,ConnectNode.position.x,Time.deltaTime*20),
            ConnectNode.position.y,
            ConnectNode.position.z +3
            );
    }
}
