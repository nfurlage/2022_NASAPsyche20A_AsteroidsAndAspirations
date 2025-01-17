﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour

    
{
    Vector3 startPoint;
    public SpriteRenderer wireEnd;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.parent.position;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;

        //update wire to move here
        transform.position = newPosition;


        //direction
        Vector3 direction =  newPosition - startPoint;
        transform.right = direction *  (transform.lossyScale.x);

        //update scale
        float dist = Vector2.Distance(startPoint, newPosition);
        wireEnd.size = new Vector2(dist, wireEnd.size.y);
    }



}
