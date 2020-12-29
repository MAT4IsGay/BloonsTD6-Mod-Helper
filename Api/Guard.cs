﻿using System;

namespace BloonsTD6_Mod_Helper.Api
{
    internal class Guard
    {
        public static void ThrowIfArgumentIsNull(object argumentObject, string argumentName, string message = "")
        {
            if (argumentObject != null)
                return;

            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException(argumentName);
            else
                throw new ArgumentNullException(argumentName, message);
        }


        public static void ThrowIfStringIsNull(string stringToCheck, string message)
        {
            if (String.IsNullOrEmpty(stringToCheck))
            {
                throw new Exception(message);
            }
        }
    }
}
