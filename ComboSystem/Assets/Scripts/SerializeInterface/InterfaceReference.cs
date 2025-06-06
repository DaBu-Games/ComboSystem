using System;
using UnityEngine;
using Object = UnityEngine.Object;

[Serializable]
public class InterfaceReference<TInterface, TObject> where TObject : Object where TInterface : class
{
    [SerializeField, HideInInspector] private TObject underLyingValue;

    public TInterface Value
    {
        get => underLyingValue switch
        {
            null => null,
            TInterface @interface => @interface,
            _ => throw new InvalidOperationException($"{underLyingValue} needs to implement interface {typeof(TInterface)}.")
        };
        set => underLyingValue = value switch
        {
            null => null,
            TObject newValue => newValue,
            _ => throw new ArgumentException($"{value} needs to be type of {typeof(TObject)}.")
        };
    }

    public TObject UnderlyingValue
    {
        get => underLyingValue;
        set => underLyingValue = value;
    }
    
    public InterfaceReference(){}
    
    public InterfaceReference(TObject target) => underLyingValue = target;
    
    public InterfaceReference(TInterface @interface) => underLyingValue = @interface as TObject;
}

[Serializable]
public class InterfaceReference<TInterface> : InterfaceReference<TInterface, Object> where TInterface : class { }