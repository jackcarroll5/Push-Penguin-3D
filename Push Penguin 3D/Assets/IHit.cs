using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    /// <summary>
    /// This interface should define what will happen if the object gets hit
    /// </summary>
    interface IHitable
    {
        /// <summary>
        /// If a IHitable object collieds with another object, this function will get called
        /// </summary>
        /// <returns>The return value will tell the object that gets hit how to react, should it stop, get destroyed, keep moving...</returns>
        Hit OnHit();
    }

