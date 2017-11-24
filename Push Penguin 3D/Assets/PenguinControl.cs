﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinControl : Movement {

    enum PlayerState{Moving, Still, Collecting, Pushing, Dying }

   
    private float currentSpeed = 10.0f;
    private float turningSpeed = 360.0f;
    private GameManagerControl theManager;



    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (shouldMoveForward()) MoveForward();


        if (shouldTurnLeft()) TurnLeft();


        if (shouldMoveBackward()) MoveBackward();

        if (shouldTurnRight()) TurnRight();


        if (shouldStrafeLeft()) StrafeLeft();


        if (shouldStrafeRight()) StrafeRight();

        if (shouldPush()) push();



        updateCameraPosition();
        //Debug.Log(playerPosition.ToString());

    }

    private void updateCameraPosition()
    {
        Camera.main.transform.position = transform.position + 2.0f * Vector3.up - 3*  transform.forward;
        Vector3 focus = transform.position + 5 * transform.forward;
        Camera.main.transform.rotation = Quaternion.LookRotation((focus - Camera.main.transform.position).normalized);
    }

    private void push()
    {
        Ray r = new Ray(transform.position, transform.forward);
        RaycastHit info = new RaycastHit();

        Debug.DrawRay(transform.position, this.transform.forward, Color.blue);
        if (Physics.Raycast(r,out info, 4f))
        {
            IceBlockController iceBlock = info.collider.GetComponent<IceBlockController>();

            if (iceBlock) iceBlock.push(this.transform.position);
            Debug.Log("RayCast works");
        }
    }

    internal void IAm(GameManagerControl gameManagerControl)
    {
        theManager = gameManagerControl;
    }

    private bool shouldPush()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    private bool shouldStrafeRight()
    {
        return Input.GetKey(KeyCode.E);
    }

    private void StrafeRight()
    {
        transform.position += currentSpeed * transform.right * Time.deltaTime;
    }

    private bool shouldStrafeLeft()
    {
        return Input.GetKey(KeyCode.Q);
    }

    private void StrafeLeft()
    {
        transform.position -= currentSpeed * transform.right * Time.deltaTime;
    }

    private bool shouldTurnRight()
    {
        return Input.GetKey(KeyCode.D);
    }

    private void TurnRight()
    {
        transform.Rotate(Vector3.up, turningSpeed * Time.deltaTime);
    }

    private void MoveBackward()
    {
        transform.position -= currentSpeed * transform.forward * Time.deltaTime;
    }

    private bool shouldMoveBackward()
    {
        return Input.GetKey(KeyCode.S);
    }

    private void TurnLeft()
    {
        transform.Rotate(Vector3.up, -turningSpeed * Time.deltaTime);
    }

    private bool shouldTurnLeft()
    {
        return Input.GetKey(KeyCode.A);
    }

    private void MoveForward()
    {
        transform.position += currentSpeed * transform.forward * Time.deltaTime;
    }

    private bool shouldMoveForward()
    {
        return Input.GetKey(KeyCode.W);
    }

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Working...");
        //if (other.gameObject.GetComponent<IceBlockController>())
        //{
        //    Debug.Log("Trigger with Ice Block Dave");
        //    MoveBackward();
        //    MoveBackward();
        //    MoveBackward();
        //    MoveBackward();
        //}
    }

    public void OnTriggerExit(Collider other)
    {
       //Debug.Log("Trigger De-activated");
       //currentSpeed = 10.0f;
      
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<IceBlockController>())
        {
            Debug.Log("Collision with Ice Block Dave");
        }
        else
            Debug.Log("not a collision we wanted");
    }
}
