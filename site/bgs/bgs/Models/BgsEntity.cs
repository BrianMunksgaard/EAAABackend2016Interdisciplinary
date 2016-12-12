using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace bgs.Models
{
    /// <summary>
    /// Top level model class. All domain classes that are saved and 
    /// restored from the database should inherit from this class.
    /// The generic repository can then be used to perform CRUD like
    /// operations on the descendant class.
    /// </summary>
    public class BgsEntity
    {
        /// <summary>
        /// Returns the current entity id.
        /// </summary>
        public virtual int EntityId
        {
            get
            {
                try
                {
                    Type t = GetType();
                    string typeName = t.Name;
                    string propertyName = typeName + "Id";
                    PropertyInfo p = t.GetProperty(propertyName);
                    if (p == null)
                    {
                        return 0;
                    }
                    else
                    {
                        return (int)p.GetValue(this, null);
                    }
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }
    }
}