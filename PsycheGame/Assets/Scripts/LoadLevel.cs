﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public float radius = 7; // within this radius, the item can be interacted with
    public Transform player; // a reference to the player object
    public string levelName; // the name of the level to be loaded

    // Update is called once per frame
    void Update()
    {
        if ( Vector3.Distance ( player.position, this.transform.position ) < radius ) 
        {
            // the "z" key acts as the interact button
            if ( Input.GetKeyDown( "z" )) 
            {
                FindObjectOfType<AudioManager>().Play("OpenMonitor");
                SceneTracker.Instance.LoadLevel( levelName );
            }
        }
    }
}
