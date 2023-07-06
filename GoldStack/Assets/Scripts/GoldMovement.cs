using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldMovement : MonoBehaviour
{
    [SerializeField] float MovementSpeed;
    [SerializeField] float HorMovement;
    float hor;
    Vector3 FirstPos, EndPos;
    void Update()
    {
        //TOUCH CONTROL
        Touch touch = Input.GetTouch(0);
        switch (touch.phase)
        {
            case TouchPhase.Began:
                FirstPos = touch.position;
                break;
            case TouchPhase.Moved:
                EndPos = touch.position;
                 hor = EndPos.x - FirstPos.x;
                break;
            case TouchPhase.Ended:
                FirstPos = Vector3.zero;
                EndPos = Vector3.zero;
                break;
        }
        transform.Translate(new Vector3(hor * Time.deltaTime * MovementSpeed/100, 0, Time.deltaTime * MovementSpeed));

        //MOUSE CONTROL
        //if(Input.GetMouseButtonDown(0))
        //{
        //    FirstPos = Input.mousePosition;
        //}
        //else if(Input.GetMouseButton(0))
        //{
        //    EndPos = Input.mousePosition;
        //    hor = EndPos.x - FirstPos.x;

        //}
        //transform.Translate(new Vector3(hor *Time.deltaTime*MovementSpeed/100, 0, Time.deltaTime * MovementSpeed));
        //if(Input.GetMouseButtonUp(0))
        //{
        //    FirstPos = Vector3.zero;
        //    EndPos = Vector3.zero;

        //}
        //Debug.Log(EndPos + " son pozisyon ");
        //Debug.Log(FirstPos + " ilk pozisyon ");


        //if (Input.touchCount==1)
        //{
        //    Touch touch = Input.GetTouch(0);
        //}
        // hor = Input.GetAxis("Horizontal");

    }
}
