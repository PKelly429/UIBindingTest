using System;
using UnityEngine;

[Serializable]
public class BindingType : ISerializationCallbackReceiver 
{
    [SerializeField] string assemblyQualifiedName = string.Empty;
        
    public Type Type { get; private set; }
        
    void ISerializationCallbackReceiver.OnBeforeSerialize() 
    {
        assemblyQualifiedName = Type?.AssemblyQualifiedName ?? assemblyQualifiedName;
    }

    void ISerializationCallbackReceiver.OnAfterDeserialize() 
    {
        if (!TryGetType(assemblyQualifiedName, out var type)) 
        {
            Debug.LogError($"Type {assemblyQualifiedName} not found");
            return;
        }
        Type = type;
    }

    static bool TryGetType(string typeString, out Type type) 
    {
        type = Type.GetType(typeString);
        return type != null || !string.IsNullOrEmpty(typeString);
    }
        
    // Implicit conversion from SerializableType to Type
    public static implicit operator Type(BindingType sType) => sType.Type;

    // Implicit conversion from Type to SerializableType
    public static implicit operator BindingType(Type type) => new() { Type = type };
}