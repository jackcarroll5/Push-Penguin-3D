using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Class definies the behavior of the IceBlock and implements all Interfaces to interact with other objects
/// </summary>
public class IceBlockController : MonoBehaviour, IMoveable, IHitable, IDestoryable {
    /// <summary>
    /// A Iceblock can have 3 states, still for just standing there, moving if pushed and destorying if the iceblock is in the animation of destroing and will be gone in the next seconds
    /// </summary>
    public enum IceBlockState { Still, Moving, Destroying}
    private IceBlockState currentState = IceBlockState.Still;
    /// <summary>
    /// Pointer to the world to call functions like getDestinationForIceBlock
    /// </summary>
    private WorldControl world;
    private Vector3 destinationForSlide;
    private Vector3 velocity;
    private float speedOfIceBlock = 2.0f; 

    /// <summary>
    /// Returns the status of the iceblock, can only be set by functions push and collide
    /// </summary>
    public IceBlockState GetIceBlockState { get { return this.currentState; } }

    /// <summary>
    /// definies the behavior of the icebock on a push. this function will check if the iceblock should be moving or should be destroyed
    /// </summary>
    /// <param name="pusherPosition">the position of the object who wants to move the iceblock</param>
    public void push(Vector3 pusherPosition)
    {
        if (world == null)
            throw new Exception("You must call \"ThisIsMe\" after creating this object or the movement won't work!");

        // Find info for movement from world;
        destinationForSlide = world.getDestinationForIceblock(this, pusherPosition);
        // if destination is the same as position destroy block;
        velocity = speedOfIceBlock * (destinationForSlide - transform.position).normalized; // check for 0
        currentState = IceBlockState.Moving;
    }

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start () {

	}

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update ()
    {
        CheckForTest();

        switch (currentState)
        {
            case IceBlockState.Still:
                // dont do anything
                break;
            case IceBlockState.Destroying:
                //todo: destroying the iceblock
                break;
            case IceBlockState.Moving:
                transform.position += velocity* Time.deltaTime;
                //if this state is moving then do:
                //question for finals: how to check for direction, how to normalize a vector, how to smoth move an object
                //vector3.dot check for 0, - or + for direction and going over destination
                //if direction change, stop moving (and jump to destination if over?)
                if (DestinationReached())
                {
                    currentState = IceBlockState.Still;
                    transform.position = destinationForSlide;
                }                
                break;
        }
    }

    /// <summary>
    /// Must be called by the world on create to do the callback for onPush
    /// </summary>
    /// <param name="worldControl">Pointer to the world</param>
    internal void ThisIsMe(WorldControl worldControl)
    {
        world = worldControl; 
    }

    /// <summary>
    /// Testfunction for Debugingpurpose
    /// </summary>
    private void CheckForTest()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            push(new Vector3(1.1f, 0, 6.5f));
        }   
    }

    /// <summary>
    /// Checks if the movement should be stoped
    /// </summary>
    /// <returns></returns>
    private bool DestinationReached()
    {
        return Vector3.Dot((destinationForSlide - transform.position), velocity) < 0.0f;
    }

    /// <summary>
    /// If a IHitable object collieds with another object, this function will get called
    /// </summary>
    /// <returns></returns>
    public Hit OnHit()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// If you want to destroy an object you call this method and on success you will get a boolean true back
    /// </summary>
    /// <returns>destoried or not</returns>
    public bool DoDestroy()
    {
        throw new NotImplementedException();
    }
}
