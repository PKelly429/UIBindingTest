using System;
using UnityEngine;

namespace DataBinding
{
    [Serializable]
    public class BindingField
    {
        public BindingType bindingType;
        public string property;

        public AbstractBindableVariable GetBindingVariable(object obj)
        {
            if (bindingType.Type != obj.GetType())
            {
#if DEBUG
                Debug.LogError($"Trying to bind {obj.GetType()} to BindingField of type {bindingType.Type}");
#endif
                return null;
            }

            if (string.IsNullOrEmpty(property))
            {
                throw new ArgumentException("BindingField does not have property");
            }

            try
            {
                return (AbstractBindableVariable)bindingType.Type.GetField(property).GetValue(obj);
            }
            catch (Exception e)
            {
                throw new ArgumentException("BindingField property does not exist.");
            }
        }
    }
}