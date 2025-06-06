using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field)]
public class RequireInterfaceAttribute : PropertyAttribute
{
   public readonly Type InterfaceType;

   public RequireInterfaceAttribute(Type interfaceType)
   {
      Debug.Assert(interfaceType.IsInterface, interfaceType.Name + " Interface type should be an interface");
      this.InterfaceType = interfaceType;
   }
}
