﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    private GameObject player;    // A refrence to the player game object
    private Vector3 offset;  // Stores the offset distance between the player and camera

    public bool border;   // Checks if the is enabled

    public float minX;
    public float maxX;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (border){
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, transform.position.z);
        }
        */
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.position.x > maxX && transform.position.x < minX){
            if (border){
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, transform.position.z);
            }
        } else {
            // Follow player
            transform.position = player.transform.position + offset;
        }
    }
}
