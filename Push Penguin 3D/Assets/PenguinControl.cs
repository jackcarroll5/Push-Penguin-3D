using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinControl : Movement {

    enum PlayerState{Moving, Still, Collecting, Pushing, Dying }

    GameObject cameraControl;
	private Vector3 playerPosition;
    private float currentSpeed = 10.0f;
    private float turningSpeed = 360.0f;

    public Vector3 getPlayerPosition() {
        return playerPosition;
	}
    public void setPosition(Vector3 setPos) 
    {
        this.transform.position = playerPosition;
    }

	// Use this for initialization
	void Start () {
        transform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update () {

        if (shouldMoveForward()) MoveForward();

        if (shouldTurnLeft()) TurnLeft();

        if (shouldMoveBackward()) MoveBackward();

        if (shouldTurnRight()) TurnRight();

        if (shouldStrafeLeft()) StrafeLeft();

        if (shouldStrafeRight()) StrafeRight();




      /* playerPosition = this.getPlayerPosition();

        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		if (direction.x != 0)
        {
            MoveX(gameObject, direction.x);
        }
        if (direction.z != 0)
        {
            MoveZ(gameObject, direction.z);
        }*/

        //mouse movement
        //

        //if()

        
            

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
}
