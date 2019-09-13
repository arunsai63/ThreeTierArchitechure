using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Reflection;

namespace DomainLayer
{
    public static class GenericMapper
    {
        // Map method takes two objects and maps the public propeties of first object with the public properties of second object
        public static void Map(object sourceObj, object destinationObj)
        {
            foreach(PropertyInfo destinationProperty in destinationObj.GetType().GetProperties())
            {
                PropertyInfo sourcePropery = sourceObj.GetType().GetProperty(destinationProperty.Name);
                if(sourcePropery == null || destinationProperty.PropertyType != sourcePropery.PropertyType || !sourcePropery.CanRead || !destinationProperty.CanWrite)
                {
                    // property not found or is of different type or cannot read/write
                    continue;
                }

                try
                {
                    if(sourcePropery.PropertyType.IsValueType || sourcePropery.PropertyType == typeof(string))
                    {
                        destinationProperty.SetValue(destinationObj, sourcePropery.GetValue(sourceObj));
                    }
                    else if(sourcePropery.PropertyType.IsClass)
                    {
                        destinationProperty.SetValue(destinationObj, Activator.CreateInstance(destinationProperty.PropertyType));
                        Map(sourcePropery.GetValue(sourceObj), destinationProperty.GetValue(destinationObj));
                    }
                    else if(sourcePropery.PropertyType.IsInterface)
                    {
                        destinationProperty.SetValue(destinationObj, Activator.CreateInstance(sourcePropery.GetValue(sourceObj).GetType()));
                        Map(sourcePropery.GetValue(sourceObj), destinationProperty.GetValue(destinationObj));
                    }
                    else //for remaining types
                    {
                        object sourceValue = sourcePropery.GetValue(sourceObj);
                        destinationProperty.SetValue(destinationObj, sourceValue);
                    }
                }
                catch(ArgumentException)
                {
                    // getter/setter not found/acccesible
                    // occurs for property.getvalue or property.setvalue
                }
                catch(RuntimeBinderException)
                {
                    // value of the property is null
                    // occurs if any of parameters is null especially if source property is null
                }
                catch(MissingMethodException)
                {
                    // No parameterless constructor defined for object
                    // occurs for Activator.CreateInstance
                }
            }
        }
    }
}
