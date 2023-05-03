using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace SZC_API.Services
{
    public class Instantiator<T> where T : new()
    {
        private T instance;
        private readonly IDictionary<string, PropertyInfo> properties;

        public Instantiator()
        {
            Type type = typeof(T);
            properties = type.GetProperties().GroupBy(p => p.Name).ToDictionary(g => g.Key, g => g.ToList().First());
        }

        public void CreateNewInstance()
        {
            instance = new T();
        }

        public void SetValue(string pPropertyName, object pValue)
        {
            if (pPropertyName == null) return;
            PropertyInfo property;
            if (!properties.TryGetValue(pPropertyName, out property)) return;
            TypeConverter tc = TypeDescriptor.GetConverter(property.PropertyType);
            if (property.PropertyType == typeof(bool)) property.SetValue(instance, bool.Parse(pValue.ToString()), null);
            else property.SetValue(instance, tc.ConvertTo(pValue, property.PropertyType), null);
        }

        public T GetInstance()
        {
            return instance;
        }
    }
}