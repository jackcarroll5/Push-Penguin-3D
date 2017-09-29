using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IceBlockController : MonoBehaviour, IMoveable {
    enum IceBlockState { Still, Moving, Destroying}
    IceBlockState currentState = IceBlockState.Still;
    WorldControl world;
    Vector3 destinationForSlide;
    private Vector3 velocity;
    float speedOfIceBlock = 2.0f;


 

    public void push(Vector3 pusherPosition)
    {
        // Find info for movement from world;
        //

        destinationForSlide = world.getDestinationForIceblock(this, pusherPosition);
        // if destination is the same as position destroy block;

        velocity = speedOfIceBlock * (destinationForSlide - transform.position).normalized; // check for 0
        currentState = IceBlockState.Moving;

    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {

            test();

        }

        switch (currentState)
        {

            case IceBlockState.Still:

                break;

            case IceBlockState.Destroying:

                // TO DO
                break;
            case IceBlockState.Moving:
                transform.position += velocity* Time.deltaTime;
                //if this state is moving then do:
                //question for finals: how to check for direction, how to normalize a vector, how to smoth move an object
                //vector3.dot check for 0, - or + for direction and going over destination
                //if direction change, stop moving (and jump to destination if over?)
                if (DestrinationReaced())
                {
                    currentState = IceBlockState.Still;

                    transform.position = destinationForSlide;
                }
                
                break;


        }



    }

    internal void ThisIsMe(WorldControl worldControl)
    {
        world = worldControl;
    }

    private void test()
    {
     

        push(new Vector3(1.1f, 0, 6.5f));
       
    }

    private bool DestrinationReaced()
    {
        return Vector3.Dot((destinationForSlide - transform.position), velocity) < 0.0f;
    }
}
