using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public class TextBinding : MonoBehaviour
{
    public TMP_Text text;
    public BindingField target;

    private AbstractBindableVariable bindableVariable;

    public void OnDisable()
    {
        Unbind();
    }

    public void Bind(object obj)
    {
        Unbind();
        
        bindableVariable = target.GetBindingVariable(obj);
        if (bindableVariable == null) return;
        
        bindableVariable.onValueChanged += OnValueChanged;
        OnValueChanged();
    }

    private void Unbind()
    {
        if (bindableVariable == null) return;
        bindableVariable.onValueChanged -= OnValueChanged;
        bindableVariable = null;

    }
    
    private void OnValueChanged()
    {
        text.text = bindableVariable.value.ToString();
    }
}