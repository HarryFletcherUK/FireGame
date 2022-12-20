using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    /// <summary>
    /// Toggles the bool to the opposite of its current value
    /// </summary>
    /// <param name="value"></param>
    /// <returns>the new value after the toggle has taken place</returns>
    public static bool Toggle(this ref bool value)
    {
        value = !value;
        return value;
    }
}
