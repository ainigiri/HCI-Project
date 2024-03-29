﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    public GameObject ball;
    public GameObject hands;
    public float handPower;

    bool inHands = false;
    Collider ballCol;
    Rigidbody ballRb;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        ballCol = ball.GetComponent<SphereCollider>();
        ballRb = ball.GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            if(!inHands && hands.GetComponent<Grab>().canGrab)
            {
                ballCol.isTrigger = true;
                ballRb.useGravity = false;
                ball.transform.SetParent(hands.transform);
                ball.transform.localPosition = new Vector3(0f,-0.75f,0f);
                ballRb.velocity = Vector3.zero;
                inHands = true;
            } else if(inHands)
            {
                ballCol.isTrigger = false;
                ballRb.useGravity = true;
                this.GetComponent<PlayerGrab>().enabled = false;
                ball.transform.SetParent(null);
                ballRb.velocity = cam.transform.rotation*Vector3.forward*handPower;
                inHands = false;
            }
            
        }
    }
}
