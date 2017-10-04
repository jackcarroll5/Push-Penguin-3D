using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Show the requested behavior on a hit, for example if the iceblock hits an enemy the enemy would return stop
/// </summary>
public enum Hit
    {
    /// <summary>
    /// on hit, the collider should do nothing
    /// </summary>
    none,
    /// <summary>
    /// on hit,  the collider should  keep on moving
    /// </summary>
    move,
    /// <summary>
    /// on hit,  the collider should stop
    /// </summary>
    stop,
    /// <summary>
    ///  the collider should be destroyed
    /// </summary>
    destory,
    /// <summary>
    ///  the collider should be killed
    /// </summary>
    kill
}

