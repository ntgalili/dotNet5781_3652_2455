using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class DeepCopyUtilities
    {
        /// <summary>
        /// copy propertis of one object to enothr object
        /// </summary>
        /// <typeparam name="T">the copy type object</typeparam>
        /// <typeparam name="S">the source type object</typeparam>
        /// <param name="from">the source object</param>
        /// <param name="to">the copy object</param>
        public static void CopyPropertiesTo<T, S>(this S from, T to)
        {
            foreach (PropertyInfo propTo in to.GetType().GetProperties())//Go over all the properties
            {
                PropertyInfo propFrom = typeof(S).GetProperty(propTo.Name);
                if (propFrom == null)
                    continue;
                var value = propFrom.GetValue(from, null);

                try
                {
                    if (value is ValueType || value is string)
                        propTo.SetValue(to, value);
                }
                catch(Exception ex)
                { }

            }
        }


        /// <summary>
        ///  copy propertis of one object to a new  object
        /// </summary>
        /// <typeparam name="S">the source type object</typeparam>
        /// <param name="from">the source object</param>
        /// <param name="type">the type of the new object</param>
        /// <returns></returns>
        public static object CopyPropertiesToNew<S>(this S from, Type type)
        {
            object to = Activator.CreateInstance(type); // new object of Type
            from.CopyPropertiesTo(to);
            return to;
        }

    }
}
