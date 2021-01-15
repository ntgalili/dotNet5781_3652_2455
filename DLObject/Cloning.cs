using System;
using System.Reflection;
//using DO;

namespace DL
{
    /// <summary>
    /// Cloning an object
    /// </summary>
    static class Cloning
    {
        /// <summary>
        /// return a new cloning of object
        /// </summary>
        /// <typeparam name="T">type of object</typeparam>
        /// <param name="original">object to clone</param>
        /// <returns>a Cloning an object</returns>
        internal static T Clone<T>(this T original) where T : new()
        {
            T copyToObject = new T(); 
            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
                propertyInfo.SetValue(copyToObject, propertyInfo.GetValue(original, null), null);
            return copyToObject;
        }
    }
}
