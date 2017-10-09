using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// This interface defines if a object is moveable and if, how
/// </summary>
interface IMoveable
    {
        /// <summary>
        /// if you want to move an object with a push, you have to call this method to give it a push
        /// </summary>
        /// <param name="pusherPosition">the pushers position to calculate the right angle to start moving an object</param>
       void push(Vector3 pusherPosition);

        
    }

