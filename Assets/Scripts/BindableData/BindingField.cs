using System;
using UnityEngine;


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
        return (AbstractBindableVariable) bindingType.Type.GetField(property).GetValue(obj);
    }
}