using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBindableVariable
{
    public Action onValueChanged;
    public abstract object value { get; set; }
}

[Serializable]
public abstract class BindableVariable<T> : AbstractBindableVariable
{
    [SerializeField]
    private T _value;
    
    public override object value
    {
        get => _value;
        set
        {
            T newValue = (T)value;
            if (EqualityComparer<T>.Default.Equals(_value, newValue)) return;
            
            _value = newValue;
            onValueChanged?.Invoke();
        }
    }
    
    public T GetValue() => _value;
    public void SetValue(T newValue)
    {
        value = newValue;
    }
    
    public static implicit operator T(BindableVariable<T> var) => var.GetValue();
}

[Serializable]
public class StringBindingVariable : BindableVariable<string>
{
}

[Serializable]
public class FloatBindingVariable : BindableVariable<float>
{
}