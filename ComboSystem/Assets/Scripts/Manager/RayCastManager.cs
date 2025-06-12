using System.Collections.Generic;
using UnityEngine;

public class RayCastManager : IAttackSubject
{
   private readonly Vector3 _direction;
   private readonly LayerMask _layerMask;
   private Vector3 _position; 
   private List<IAttackObserver> _observers = new List<IAttackObserver>();
   private float _currentDmg = 0f;

   public RayCastManager(Vector3 direction, LayerMask layerMask)
   {
      this._direction = direction;
      this._layerMask = layerMask;
   }

   public void SetPosition(Transform transform)
   {
      this._position = transform.position;
   }

   public void Raycast(float range, float dmg)
   {
      if (Physics.Raycast(_position, _direction, range, _layerMask))
      {
         _currentDmg = dmg;
         Notify();
      }
   }

   public void Attach(IAttackObserver attackObserver)
   {
      _observers.Add(attackObserver);
   }

   public void Detach(IAttackObserver attackObserver)
   {
      _observers.Remove(attackObserver);
   }

   public void Notify()
   {
      foreach (IAttackObserver observer in _observers)
      {
         observer.Update(this, _currentDmg);
      }
   }
}
