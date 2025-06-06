using System;
using UnityEngine;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;

[Serializable]
public class InterfaceReference<TInterface, TObject> where TObject : Object where TInterface : class
{
    [SerializeField, HideInInspector] private TObject underlyingValue;

    public TInterface Value
    {
        get
        {
            if (underlyingValue == null) return null;
            else if (underlyingValue is TInterface @interface) return @interface;
            else throw new InvalidOperationException($"{underlyingValue} needs to implement interface {typeof(TInterface)}.");
        }
        set => underlyingValue = value switch
        {
            null => null,
            TObject newValue => newValue,
            _ => throw new ArgumentException($"{value} needs to be type of {typeof(TObject)}.")
        };
    }

    public TObject UnderlyingValue
    {
        get => underlyingValue;
        set => underlyingValue = value;
    }
    
    public InterfaceReference(){}
    
    public InterfaceReference(TObject target) => underlyingValue = target;
    
    public InterfaceReference(TInterface @interface) => underlyingValue = @interface as TObject;
}

[Serializable]
public class InterfaceReference<TInterface> : InterfaceReference<TInterface, Object> where TInterface : class { }