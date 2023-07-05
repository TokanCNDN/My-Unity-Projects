﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowMove : MonoBehaviour
{
    private Vector2 mousePos;
  

   
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.right = new Vector3(mousePos.x - transform.position.x, mousePos.y - transform.position.y, 0f);

    }
}
