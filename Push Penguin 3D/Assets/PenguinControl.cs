using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinControl : Movement {

    enum PlayerState{Moving, Still, Collecting, Pushing, Dying }

    GameObject cameraControl;
	private Vector3 playerPosition;

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

        playerPosition = this.getPlayerPosition();

        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		if (direction.x != 0)
        {
            MoveX(gameObject, direction.x);
        }
        if (direction.z != 0)
        {
            MoveZ(gameObject, direction.z);
        }

        //mouse movement
        //

        //if()
            

    }
}
