using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace bgs.Models
{
    public class BgsEntity
    {
        public virtual int EntityId
        {
            get
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
        }
    }
}