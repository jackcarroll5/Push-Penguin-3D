using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    /// <summary>
    /// This interface definies if a object can be destoryed and offers a method to destroy it. for example if you want to destroy an iceblock you will call the method DoDestory()
    /// </summary>
    interface IDestoryable
    {
        /// <summary>
        /// If you want to destroy an object you call this method and on success you will get a boolean true back
        /// </summary>
        /// <returns>destoried or not</returns>
        Boolean DoDestroy();
    }

